using System;
using Gameplay.Enums;
using Gameplay.UX;
using Gameplay.View;
using Plugins.QB_Extensions;
using UnityEngine;

namespace Gameplay.Entity
{
    public class Player : MonoBehaviour
    {
        public static Player Main;
        public static Transform Transform;

        public PlayerStat Stat;

        [SerializeField] private float speed = 1;
        [SerializeField] private HpBar_Player hpBar;
        [SerializeField] private SpriteRenderer pet;

        public Action OnChanged_Hp;


        private ModelFeeling _model;

        private void Awake()
        {
            foreach (Transform child in transform)
            {
                if (!child.name.ToLower().Contains("model")) continue;
                _model = child.GetComponent<ModelFeeling>();
                break;
            }

            Stat.SetOwner(this);
            hpBar.Reflect(this);
        }

        private void OnEnable()
        {
            Main = this;
            Transform = transform;

            Stat.SetLevel(1);
        }


        public static void Move(Vector2 direction)
        {
            Transform.position += new Vector3(direction.x, direction.y) * (Main.speed * Time.deltaTime);

            Main._model.transform.Flip(direction);
            Main.pet.flipX = direction.x < 0;
        }

        public void OnDamaged(float damage)
        {
            Stat.HpCurrent -= damage;
            _model.Feeling_OnDamage();
        }

        public void OnKilled()
        {
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent<ISourceDamage>(out var source)) OnDamaged(source.Damage);
        }
    }

    [Serializable]
    public class PlayerStat
    {
        [SerializeField] private float hp = 100;


        private float _hpCurrent;

        public float HpCurrent
        {
            get => _hpCurrent;
            set
            {
                _hpCurrent = value;

                _owner.OnChanged_Hp?.Invoke();
                if (_hpCurrent <= 0) _owner.OnKilled();
            }
        }

        public float HpMax => hp;

        public float HpPercent => Mathf.Clamp01(HpCurrent / HpMax);
        private Player _owner;

        public void SetOwner(Player enemy)
        {
            _owner = enemy;
        }

        public void SetLevel(int level)
        {
            HpCurrent = HpMax;
        }
    }
}