using UnityEngine;

namespace Gameplay.UX
{
    public class Rotator : MonoBehaviour
    {
        public float speed = 0.5f;

        private void Update()
        {
            transform.Rotate(0, 0, speed * Time.deltaTime);
        }
    }
}