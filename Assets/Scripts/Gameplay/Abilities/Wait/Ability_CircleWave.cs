using DG.Tweening;
using Gameplay.Entity;
using Gameplay.Utility;
using UnityEngine;

namespace Gameplay.Abilities
{
    public class Ability_CircleWave : _Ability
    {
        [SerializeField] private EnemyDetector detector;
        [SerializeField] private Ease ease;

        protected override void Init()
        {
            detector.OnEnter += OnEnemyEnter;
        }

        protected override void Execute()
        {
            detector.gameObject.SetActive(true);

            detector.transform.localScale = Vector3.one;
            detector.transform.DOScale(3f, stat.Speed).SetEase(ease);
        }

        protected override void Interval()
        {
        }

        protected override void UnExecute()
        {
            detector.gameObject.SetActive(false);
        }

        protected void OnEnemyEnter(Enemy enemy)
        {
            // enemy.OnDamaged(stat.Damage * PlayerDamage);
        }
    }
}