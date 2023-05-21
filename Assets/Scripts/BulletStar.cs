using UnityEngine;

public class BulletStar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        var enemy = col.GetComponent<Enemy>();
        if (!enemy) return;
        
        Debug.Log("Hit!");
        enemy.OnHit();
    }
}