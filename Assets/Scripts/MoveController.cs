using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private Joystick joystick;

    private void Update()
    {
        var direction = joystick.Direction.normalized;
        if (direction.magnitude == 0) return;

        Player.Move(direction);
    }
}