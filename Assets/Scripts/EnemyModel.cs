using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();
    }

    private void OnBecameVisible()
    {
        _enemy.OnVisible();
    }

    private void OnBecameInvisible()
    {
        _enemy.OnInvisible();
    }
}