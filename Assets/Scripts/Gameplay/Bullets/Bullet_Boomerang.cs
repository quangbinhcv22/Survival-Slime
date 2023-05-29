using UnityEngine;

namespace Gameplay.Bullets
{
    public class Bullet_Boomerang : _Bullet
    {
        public const float ReachedDistance = 0.5f;
        [SerializeField] private float rotationSpeed = 180f;
        private bool _returning = false;

        
        protected override void SetUpShoot()
        {
            base.SetUpShoot();
            _returning = false;
        }

        protected override void Update()
        {
            if (!_returning)
            {
                var position = cachedTrans.position;
                position += dir * (stat.Speed * Time.deltaTime);

                cachedTrans.position = position;
                cachedTrans.Rotate(0, 0, -rotationSpeed * Time.deltaTime);

                _returning = Vector3.Distance(position, root.position) >= stat.Range;
            }
            else
            {
                var position = cachedTrans.position;
                var direction = (root.position - position).normalized;

                position += direction * (stat.Speed * Time.deltaTime);
                cachedTrans.position = position;
                cachedTrans.Rotate(0, 0, -rotationSpeed * Time.deltaTime);


                if (Vector2.Distance(cachedTrans.position, root.position) <= ReachedDistance)
                {
                    cachedTrans.position = root.position;
                    ReturnPool();
                }
            }
        }
    }
}