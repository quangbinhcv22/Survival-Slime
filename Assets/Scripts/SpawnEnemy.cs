using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    [Space, SerializeField] private List<string> enemies;
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
        // if(maxAtOnce)
        
        var key = enemies[Random.Range(0, enemies.Count)];
        PoolEnemy.Get(key, enemy => { enemy.transform.position = Player.Transform.position + RandomOffset; });
    }

    private Vector3 RandomOffset
    {
        get
        {
            var position = new Vector2();

            while (Mathf.Abs(position.x) < minRange.x && Mathf.Abs(position.y) < minRange.y)
            {
                position.x = Random.Range(-maxRange.x, maxRange.x);
                position.y = Random.Range(-maxRange.y, maxRange.y);
            }

            return position;
        }
    }
}