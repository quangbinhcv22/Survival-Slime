using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using Plugins.QB_UI.Core;
using UnityEngine;

namespace UIFlow.Upgrade
{
    public class Sheet_UpgradeStat : Panel, IEnhancedScrollerDelegate
    {
        [Space, SerializeField] private EnhancedScroller scroller;
        [SerializeField] private UpgradeStat_Cell cellPrefab;
        [SerializeField] private float cellSize = 200f;
        
        [Space, SerializeField] List<UpgradeStat_Data> data = new();

        
        private void OnEnable()
        {
            scroller.Delegate = this;
        }

        public int GetNumberOfCells(EnhancedScroller scroller) => data.Count;

        public float GetCellViewSize(EnhancedScroller scroller, int dataIndex) => cellSize;

        public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
        {
            var cell = (UpgradeStat_Cell)this.scroller.GetCellView(cellPrefab);

            cell.SetIndex(cellIndex);
            cell.SetData(data[dataIndex]);

            return cell;
        }
    }
}