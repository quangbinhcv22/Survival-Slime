using Gameplay.Entity;

namespace Gameplay.UX
{
    public class ModelFeeling_Enemy : ModelFeeling
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
}