using System;
using TMPro;
using UIFlow._Reusable;
using UnityEngine;
using UnityEngine.UI;

namespace UIFlow.Upgrade
{
    public class UpgradeStat_Cell : CellView_IndexColor
    {
        [Space, SerializeField] private Image icon;
        [SerializeField] private TMP_Text txtLv;
        
        public void SetData(UpgradeStat_Data data)
        {
        }
    }
}