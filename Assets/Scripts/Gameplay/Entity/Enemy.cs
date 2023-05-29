using System;
using System.Collections.Generic;
using Gameplay.Enums;
using Gameplay.Pool;
using Gameplay.UX;
using Gameplay.View;
using Plugins.QB_Extensions;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Random = UnityEngine.Random;

namespace Gameplay.Entity
{
    public class Enemy : MonoBehaviour, ISourceDamage
    {
        public static readonly List<Enemy> All = new();
        public static readonly List<Enemy> VisibleEnemies = new();


        [Space, SerializeField] private float moveSpeed = 1f;
        [SerializeField] private float keepDistance = 0.5f;

        [Space, SerializeField] private AssetReference loot;


        private BoxCollider2D _collider;
        private ModelFeeling_Enemy _model;

        [Space] public EnemyStat Stat;
        public float Damage => Stat.Damage;


        private void Awake()
        {
            _collider = GetComponent<BoxCollider2D>();
            _model = GetComponentInChildren<ModelFeeling_Enemy>();

            Stat.SetOwner(this);
        }

        private void Update()
        {
            var moveDirection = (Player.Transform.position - transform.position).normalized;
            Move(moveDirection);

            if (_visible)
            {
                KeepDistance();
            }
        }

        private void Move(Vector2 direction)
        {
            transform.position += new Vector3(direction.x, direction.y) * (moveSpeed * Time.deltaTime);
            _model.transform.Flip(direction);
        }

        private void KeepDistance()
        {
            foreach (var enemy in VisibleEnemies)
            {
                if (enemy == this) continue;

                var position = transform.position;

                var distance = Vector3.Distance(position, enemy.transform.position);
                if (distance > keepDistance) continue;

                var direction = (position - enemy.transform.position).normalized;
                transform.position += new Vector3(direction.x, direction.y) * (moveSpeed * Time.deltaTime);
            }
        }

        public void OnDamaged(float damage, DamageType damageType)
        {
            var isCrit = Random.Range(0, 100f) < 30f;
            damage *= Random.Range(0.9f, 1.1f);
            if (isCrit) damage *= 2;

            Stat.HpCurrent -= damage;

            FloatText.ShowAt(damage, damageType, isCrit, transform.position);
            HpBar_Enemy.Show(this);

            _model.Feeling_OnDamage();
        }

        public void OnKilled()
        {
            BattleM.Main.StatisticKilled();
            Pooler.Get(loot, l => l.transform.position = transform.position);

            gameObject.SetActive(false);
        }


        private bool _visible;

        public void OnVisible()
        {
            _visible = true;
            VisibleEnemies.Add(this);

            _collider.enabled = true;
        }

        public void OnInvisible()
        {
            _visible = false;
            VisibleEnemies.Remove(this);

            _collider.enabled = false;
        }

        private void OnEnable()
        {
            All.Add(this);
            Stat.SetLevel(1);
        }

        private void OnDisable()
        {
            All.Remove(this);
        }
    }


    [Serializable]
    public class EnemyStat
    {
        [SerializeField] private float hp = 100;
        [SerializeField] private float damage = 10;


        private float _hpCurrent;

        public float HpCurrent
        {
            get => _hpCurrent;
            set
            {
                _hpCurrent = value;
                if (_hpCurrent <= 0) _owner.OnKilled();
            }
        }

        public float HpMax => hp;

        public float HpPercent => Mathf.Clamp01(HpCurrent / HpMax);
        public float Damage => damage;


        private Enemy _owner;

        public void SetOwner(Enemy enemy)
        {
            _owner = enemy;
        }

        public void SetLevel(int level)
        {
            HpCurrent = HpMax;
        }
    }
}