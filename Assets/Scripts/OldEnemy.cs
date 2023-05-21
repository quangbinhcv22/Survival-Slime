using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class OldEnemy : MonoBehaviour
{
    private static readonly List<OldEnemy> Enemies = new();

    public float moveSpeed = 1f;
    public float minDistanceToEnemy = 1f;
    private Transform _model;

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            if (!child.name.ToLower().Contains("model")) continue;
            
            _model = child.transform;
            break;
        }
    }

    private void OnEnable()
    {
        Enemies.Add(this);
    }

    private void OnDisable()
    {
        Enemies.Remove(this);
    }


    private void Update()
    {
        MoveTowardsPlayer();
        AvoidOtherEnemies();
    }

    private void MoveTowardsPlayer()
    {
        var moveDirection = (Player.Transform.position - transform.position).normalized;
        Move(moveDirection);
    }

    private void AvoidOtherEnemies()
    {
        foreach (OldEnemy enemy in Enemies)
        {
            if (enemy == this) continue;

            var distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (!(distance < minDistanceToEnemy)) continue;

            var direction = (transform.position - enemy.transform.position).normalized;
            transform.position += new Vector3(direction.x, direction.y) * (moveSpeed * Time.deltaTime);
        }
    }

    public void Move(Vector2 direction)
    {
        transform.position += new Vector3(direction.x, direction.y) * (moveSpeed * Time.deltaTime);
        _model.Flip(direction);
    }
}