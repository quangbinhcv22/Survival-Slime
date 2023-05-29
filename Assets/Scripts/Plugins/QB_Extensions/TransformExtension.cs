using UnityEngine;

namespace Plugins.QB_Extensions
{
    public static class TransformExtension
    {
        public static void Flip(this Transform transform, Vector2 direction)
        {
            var directionSign = Mathf.Sign(direction.x);
            if ((int)directionSign == (int)Mathf.Sign(transform.localScale.x)) return;

            var newScale = transform.localScale;
            newScale.x = Mathf.Abs(newScale.x) * Mathf.Sign(direction.x);

            transform.localScale = newScale;
        }
    
        public static void LookAt2D(this Transform transform, Vector3 target)
        {
            var diff = (target - transform.position).normalized;
            var rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
        }
    }
}