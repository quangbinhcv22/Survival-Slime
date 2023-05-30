using System;
using System.Collections.Generic;
using UnityEngine;

namespace UIFlow.Shop
{
    public class BattlePass_Config : MonoBehaviour
    {
        public int baseRequired = 750;
        public int upRequired = 150;
        public int maxLevel = 30;

        public List<int> preview;

        [Space] public int xpPerBattle = 1500;
        public int minutesPerBattle = 15;
        public int daysPerPack = 14;

        [Space] public int totalLv;
        public int totalXp;
        public float battleRequired;
        public float minutesRequired;
        public float hoursRequired;
        public float battlePerDay;

        [Space] public int currentXp = 5;
        public BattlePass_Progress progress;

        public int RequiredXp_ToNext(int level)
        {
            return baseRequired + level * upRequired;
        }

        public int TotalRequired_ToNext(int level)
        {
            var xp = 0;
            for (var i = 1; i <= level; i++) xp += RequiredXp_ToNext(i);
            return xp;
        }

        public BattlePass_Progress ProgressOfXp(int xp)
        {
            var progress = new BattlePass_Progress { level = 1 };

            while (xp > TotalRequired_ToNext(progress.level)) progress.level++;

            progress.xpCurrent = xp - TotalRequired_ToNext(progress.level - 1);
            progress.xpRequired = RequiredXp_ToNext(progress.level);

            return progress;
        }

        private void OnValidate()
        {
            preview.Clear();
            
            for (int i = 1; i < maxLevel; i++)
            {
                preview.Add(RequiredXp_ToNext(i));
            }

            totalXp = TotalRequired_ToNext(totalLv);
            battleRequired = (float)totalXp / xpPerBattle;
            minutesRequired = battleRequired * minutesPerBattle;
            hoursRequired = minutesRequired / 60f;
            battlePerDay = battleRequired / daysPerPack;

            progress = ProgressOfXp(currentXp);
        }
    }

    [Serializable]
    public class BattlePass_Progress
    {
        public int level;
        public int xpCurrent;
        public int xpRequired;

        public float XpPercent => (float)xpCurrent / xpRequired;
    }
}