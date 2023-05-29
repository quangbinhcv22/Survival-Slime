using Gameplay.Entity;
using Gameplay.Pool;
using Gameplay.Utility;
using Plugins.QB_Extensions;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Gameplay.Bullets
{
    public class Bullet_Rocket : MonoBehaviour
    {
        [SerializeField] private AssetReference vfxRef;
        [SerializeField] private float speed = 10f;
        [SerializeField] private EnemyDetector detector;

        private Vector3 _direction;

        public void Shot(Vector2 startPos, Vector2 targetPos)
        {
            transform.position = startPos;
            transform.LookAt2D(targetPos);

            _direction = (targetPos - startPos).normalized;
        }

        private void Update()
        {
            transform.position += _direction * (Time.deltaTime * speed);
        }

        private void OnBecameInvisible()
        {
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            // if (!col.GetComponent<Enemy>()) return;
            //
            // foreach (var enemy in detector.Enemies)
            // {
            //     enemy.OnDamaged(750);
            // }
            //
            // gameObject.SetActive(false);
            //
            // Pooler.Get(vfxRef, transform.position);
        }
    }
}