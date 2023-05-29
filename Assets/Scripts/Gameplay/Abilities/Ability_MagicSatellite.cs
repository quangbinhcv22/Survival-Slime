using Gameplay.Bullets;
using Gameplay.Pool;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Gameplay.Abilities
{
    public class Ability_MagicSatellite : _Ability
    {
        [Space, SerializeField] private AssetReference bulletRef;
        [SerializeField] private float rotateSpeed = 180f;

        protected override void Init()
        {
        }

        protected override void Execute()
        {
            var angleStep = 360f / stat.Amount;

            for (var i = 0; i < stat.Amount; i++)
            {
                var index = i;

                Pooler.Get(bulletRef, bullet =>
                {
                    var angle = index * angleStep;

                    var x = stat.Range * Mathf.Cos(Mathf.Deg2Rad * angle);
                    var y = stat.Range * Mathf.Sin(Mathf.Deg2Rad * angle);
                    var direction = new Vector3(x, y, 0);

                    bullet.transform.SetParent(transform);
                    bullet.transform.localPosition = direction;
                    bullet.transform.localScale = Vector3.one * stat.Size;

                    bullet.GetComponent<_Bullet>().Shoot(this, transform.position, direction);
                });
            }
        }

        protected override void Interval()
        {
        }

        protected override void UnExecute()
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            transform.Rotate(0, 0, rotateSpeed * stat.Speed * Time.deltaTime);
        }
    }
}