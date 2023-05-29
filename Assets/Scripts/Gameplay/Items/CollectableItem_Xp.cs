using System.Collections.Generic;

namespace Gameplay.Items
{
    public class CollectableItem_Xp : _CollectableItem
    {
        public static readonly List<CollectableItem_Xp> All = new();

        public int value = 50;

        protected override void OnCollect_Begin()
        {
        }

        protected override void OnCollect_End()
        {
            BattleM.Main.lvProgress.AddXp(value);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            All.Add(this);
        }

        protected void OnDisable()
        {
            All.Remove(this);
        }
    }
}