using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using Plugins.QB_UI.Core;
using UnityEngine;

namespace UIFlow.Upgrade
{
    public class Sheet_UpgradeActive : Panel, IEnhancedScrollerDelegate
    {
        [Space, SerializeField] private EnhancedScroller scroller;
        [SerializeField] private UpgradeActive_Cell cellPrefab;
        [SerializeField] private float cellSize = 200f;

        [Space, SerializeField] List<UpgradeActive_Data> data = new();


        private void OnEnable()
        {
            scroller.Delegate = this;
        }

        public int GetNumberOfCells(EnhancedScroller scroller) => data.Count;

        public float GetCellViewSize(EnhancedScroller scroller, int dataIndex) => cellSize;

        public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
        {
            var cell = (UpgradeActive_Cell)this.scroller.GetCellView(cellPrefab);

            cell.SetIndex(cellIndex);
            cell.SetData(data[dataIndex]);

            return cell;
        }
    }
}