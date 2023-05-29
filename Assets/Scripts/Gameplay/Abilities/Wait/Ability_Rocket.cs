using System.Linq;
using Gameplay.Bullets;
using Gameplay.Entity;
using Gameplay.Pool;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Gameplay.Abilities
{
    public class Ability_Rocket : _Ability
    {
        public AssetReference rocketRef;

        protected override void Init()
        {
        }

        protected override void Execute()
        {
            var nearEnemies = Enemy.VisibleEnemies
                .OrderBy(e => Vector3.Distance(e.transform.position, transform.position)).ToList();
            if (!nearEnemies.Any()) return;

            var targets = nearEnemies.GetRange(0, Mathf.Min(stat.Amount, nearEnemies.Count));

            foreach (var target in targets)
            {
                Pooler.Get(rocketRef,
                    rocket =>
                    {
                        rocket.GetComponent<Bullet_Rocket>().Shot(transform.position, target.transform.position);
                    });
            }
        }

        protected override void Interval()
        {
        }

        protected override void UnExecute()
        {
        }
    }
}