using Gameplay.Pool;
using Gameplay.Utility;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Gameplay.Abilities
{
    public class Ability_LavaPit : _Ability
    {
        [SerializeField] private AssetReference lavaRef;
        private EnemyDetector _detector;

        protected override void Init()
        {
        }

        protected override void Execute()
        {
            Pooler.Get(lavaRef, lava =>
            {
                lava.transform.position = transform.position;
                _detector = lava.GetComponent<EnemyDetector>();
            });
        }

        protected override void Interval()
        {
            if (_detector == null) return;
            foreach (var enemy in _detector.Enemies) TakeDamage(enemy);
        }

        protected override void UnExecute()
        {
            _detector.gameObject.SetActive(false);
            _detector = null;
        }
    }
}