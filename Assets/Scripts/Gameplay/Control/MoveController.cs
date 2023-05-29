using Gameplay.Entity;
using UnityEngine;

namespace Gameplay.Control
{
    public class MoveController : MonoBehaviour
    {
        public static Vector3 Direction = Vector3.right;

        [SerializeField] private Joystick joystick;

        private void Update()
        {
            var direction = joystick.Direction.normalized;
            if (direction.magnitude == 0) return;

            Direction = direction;
            Player.Move(direction);
        }
    }
}