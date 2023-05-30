using System.Collections.Generic;
using DataCore;
using Plugins.QB_UI.Core;
using UnityEngine;
using ProgressBar = Ui.ProgressBar;

namespace UIFlow.Shop
{
    public class Screen_BattlePass : Panel
    {
        public List<Gift> freePack;
        public List<Gift> vipPack;
        public List<Gift> premiumPack;

        [Space] [SerializeField] private BattlePass_Config config;

        [Space] [SerializeField] private Transform levelGroup;
        [SerializeField] private Transform xpGroup;

        [Space] [SerializeField] private BattlePass_CellLevel[] levelCells;
        [SerializeField] private ProgressBar[] xpCells;

        private void Awake()
        {
            levelCells = levelGroup.GetComponentsInChildren<BattlePass_CellLevel>();
            xpCells = xpGroup.GetComponentsInChildren<ProgressBar>();
        }

        protected override void OnValidate()
        {
            base.OnValidate();

            levelCells = levelGroup.GetComponentsInChildren<BattlePass_CellLevel>();
            xpCells = xpGroup.GetComponentsInChildren<ProgressBar>();

            var currentLevel = config.progress.level;

            for (int i = 0; i < levelCells.Length; i++)
            {
                var cellLv = i + 1;
                levelCells[i].SetLevel(cellLv);
                levelCells[i].SetUnlock(currentLevel >= cellLv);
            }

            for (int i = 0; i < xpCells.Length; i++)
            {
                var cellLv = i + 1;

                var fill = 0f;
                if (currentLevel > cellLv) fill = 1;
                else if (currentLevel < cellLv) fill = 0;
                else fill = config.progress.XpPercent;
                
                xpCells[i].SetFillImmediately(fill);
            }
        }
    }
}