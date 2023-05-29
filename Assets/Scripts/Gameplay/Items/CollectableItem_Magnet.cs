using UnityEngine;

namespace Gameplay.Items
{
    public class CollectableItem_Magnet : _CollectableItem
    {
        [Space, SerializeField] private float tweenScale = 3f;
    
        protected override void OnCollect_Begin()
        {
        }

        protected override void OnCollect_End()
        {
            CollectableItem_Xp.All.ForEach(xp => xp.Collect(Collector, tweenScale));
        }
    }
}