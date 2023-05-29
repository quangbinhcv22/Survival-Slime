using Gameplay.Utility;
using UnityEngine;

namespace Gameplay.Abilities
{
    public class Ability_MagicBoundary : _Ability
    {
        [SerializeField] private EnemyDetector detector;

        protected override void Init()
        {
        }

        protected override void Execute()
        {
            detector.gameObject.SetActive(true);
        }

        protected override void Interval()
        {
            foreach (var enemy in detector.Enemies) TakeDamage(enemy);
        }

        protected override void UnExecute()
        {
            detector.gameObject.SetActive(false);
        }
    }
}