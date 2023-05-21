using System;
using UnityEngine;

public class Active_StarBullet : MonoBehaviour
{
    [NonSerialized] public Active_StarGun root;

    private Vector3 _startPos;
    private Vector3 _direction;

    
    public void Shoot(Vector3 direction)
    {
        _startPos = transform.position;
        _direction = direction;
    }

    private void Update()
    {
        transform.position += _direction * (root.speed * Time.deltaTime);

        if ((_startPos - transform.position).magnitude >= root.radius)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        root.OnHit(gameObject, col.gameObject);
    }
}