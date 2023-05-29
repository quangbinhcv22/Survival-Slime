using System.Linq;
using Gameplay.Entity;

namespace Gameplay.Items
{
    public class CollectableItem_Bomb : _CollectableItem
    {
        protected override void OnCollect_Begin()
        {
        }

        protected override void OnCollect_End()
        {
            foreach (var enemy in Enemy.All.ToList())
            {
                enemy.OnKilled();
            }
        }
    }
}