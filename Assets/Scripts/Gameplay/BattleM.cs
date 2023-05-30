using System;
using Gameplay.Progress;
using Plugins.QB_UI.Core;
using UnityEngine;

namespace Gameplay
{
    [DefaultExecutionOrder(int.MinValue)]
    public class BattleM : MonoBehaviour
    {
        public static BattleM Main;

        [Space] public int time = 0;


        public LevelProgress lvProgress;

        
        public int Killed;
        public Action onStatisticKilled;

        public void StatisticKilled()
        {
            Killed++;
            onStatisticKilled?.Invoke();
        }

        public void StartBattle()
        {
            lvProgress.Reset();
        }

        private void OnEnable()
        {
            Main = this;
            StartBattle();
            
            lvProgress.LevelChanged += LevelChanged;
        }

        private void LevelChanged()
        {
            if (lvProgress.Level > 1)
            {
                // PanelContainer.Main.Push<Popup_SelectAbility>();
            }
        }
    }
}