using Gameplay.Bullets;
using Gameplay.Pool;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Gameplay.Abilities
{
    public class Ability_Star : _Ability
    {
        public AssetReference bulletRef;
        public float radius = 5f;


        protected override void Init()
        {
        }

        protected override void Execute()
        {
            Shoot();
        }

        private void Shoot()
        {
            var angleStep = 360f / stat.Amount;

            for (var i = 0; i < stat.Amount; i++)
            {
                var index = i;
                Pooler.Get(bulletRef, bullet =>
                {
                    var angle = index * angleStep;

                    var x = radius * Mathf.Cos(Mathf.Deg2Rad * angle);
                    var y = radius * Mathf.Sin(Mathf.Deg2Rad * angle);
                    var direction = new Vector3(x, y, 0).normalized;

                    bullet.GetComponent<_Bullet>().Shoot(this, transform.position, direction);
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