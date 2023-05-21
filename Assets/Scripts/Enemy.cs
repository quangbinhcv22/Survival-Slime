using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private static readonly List<Enemy> VisibleEnemies = new();


    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float keepDistance = 0.5f;

    private BoxCollider2D _collider;
    private Transform _model;


    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _model = GetComponentInChildren<EnemyModel>().transform;
    }

    private void Update()
    {
        var moveDirection = (Player.Transform.position - transform.position).normalized;
        Move(moveDirection);

        if (_visible)
        {
            KeepDistance();
        }
    }

    private void Move(Vector2 direction)
    {
        transform.position += new Vector3(direction.x, direction.y) * (moveSpeed * Time.deltaTime);
        _model.Flip(direction);
    }

    private void KeepDistance()
    {
        foreach (var enemy in VisibleEnemies)
        {
            if (enemy == this) continue;

            var position = transform.position;

            var distance = Vector3.Distance(position, enemy.transform.position);
            if (distance > keepDistance) continue;

            var direction = (position - enemy.transform.position).normalized;
            transform.position += new Vector3(direction.x, direction.y) * (moveSpeed * Time.deltaTime);
        }
    }

    public void OnHit()
    {
        gameObject.SetActive(false);
    }


    private bool _visible;

    public void OnVisible()
    {
        _visible = true;
        VisibleEnemies.Add(this);

        _collider.enabled = true;
    }

    public void OnInvisible()
    {
        _visible = false;
        VisibleEnemies.Remove(this);

        _collider.enabled = false;
    }
}