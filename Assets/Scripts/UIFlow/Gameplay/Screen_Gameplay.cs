using Cysharp.Threading.Tasks;
using Gameplay;
using Gameplay.Progress;
using Plugins.QB_UI.Core;
using TMPro;
using Ui;
using UnityEngine;

namespace UIFlow.Gameplay
{
    public class Screen_Gameplay : Panel
    {
        [Space, SerializeField] private TMP_Text lvTxt;
        [SerializeField] private ProgressBar xpBar;
        
        private BattleM _battle;
        private LevelProgress _lvProgress;

        private async void OnEnable()
        {
            await UniTask.DelayFrame(5);
            
            Debug.Log("Enable");
            _battle = BattleM.Main;

            _lvProgress = _battle.lvProgress;
            _lvProgress.LevelChanged += LevelChanged;
            _lvProgress.XpChanged += XpChanged;
            
            LevelChanged();
            XpChanged();
        }


        protected override void OnOpen()
        {
        }

        protected override void OnClose()
        {
            _lvProgress.LevelChanged -= LevelChanged;
            _lvProgress.XpChanged -= XpChanged;
        }


        private void LevelChanged()
        {
            lvTxt.SetText($"Lv {_lvProgress.Level}");
        }

        private void XpChanged()
        {
            xpBar.SetFill(_lvProgress.XpCurrent, _lvProgress.XpRequired);
        }
    }
}