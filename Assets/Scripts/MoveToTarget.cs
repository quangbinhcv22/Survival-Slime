using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    
    private void Update()
    {
        Vector3 moveDirection = (Player.Transform.position - transform.position).normalized;
        transform.position += moveDirection * (moveSpeed * Time.deltaTime);
    }
}