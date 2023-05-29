using System.Collections.Generic;
using Gameplay.Entity;
using Gameplay.Pool;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Random = UnityEngine.Random;

namespace Gameplay.Spawn
{
    public class SpawnEnemy : MonoBehaviour
    {
        [Space, SerializeField] private List<AssetReference> enemies;
        [SerializeField] private float repeat = 0.5f;
        [SerializeField] private int maxAtOnce = 100;

        [Space, SerializeField] private Vector2 minRange = new(10, 10);
        [SerializeField] private Vector2 maxRange = new(15, 15);


        private void OnEnable()
        {
            InvokeRepeating(nameof(Spawn), 0f, repeat);
        }

        private void OnDisable()
        {
            CancelInvoke(nameof(Spawn));
        }

        private void Spawn()
        {
            if (Enemy.All.Count >= maxAtOnce) return;

            var spawnPos = (Vector2)(Player.Transform.position + RandomOffset);

            // for (int i = 0; i < Random.Range(5, 10); i++)
            // {
            var prefab = enemies[Random.Range(0, enemies.Count)];
            // var pos = spawnPos + Random.insideUnitCircle * 3;

            Pooler.Get(prefab.RuntimeKey.ToString(), enemy => { enemy.transform.position = spawnPos; });
            // }
        }

        private Vector3 RandomOffset
        {
            get
            {
                var position = new Vector2();

                while (Mathf.Abs(position.x) < minRange.x && Mathf.Abs(position.y) < minRange.y)
                {
                    position = Random.insideUnitCircle * 30;

                    // position.x = Random.Range(-maxRange.x, maxRange.x);
                    // position.y = Random.Range(-maxRange.y, maxRange.y);
                }

                return position;
            }
        }
    }
}