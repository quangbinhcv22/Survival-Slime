using System;
using Gameplay;
using TMPro;
using UnityEngine;

namespace Ui.Battle
{
    public class Popup_LevelUp : MonoBehaviour
    {
        [SerializeField] private TMP_Text txLevel;

        public void LevelChanged(int lv)
        {
            txLevel.SetText(lv.ToString());
        }

        private void OnEnable()
        {
            // BattleM.
        }
    }
}