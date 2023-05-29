using TMPro;
using UIFlow._Reusable;
using UnityEngine;
using UnityEngine.UI;

namespace UIFlow.Upgrade
{
    public class UpgradeActive_Cell : CellView_IndexColor
    {
        [Space, SerializeField] private Image icon;
        [SerializeField] private TMP_Text txtLv;
        
        public void SetData(UpgradeActive_Data data)
        {
        }
    }
}