using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using Plugins.QB_UI.Core;
using UnityEngine;

namespace UIFlow.Explore
{
    public class Sheet_Endless : Panel, IEnhancedScrollerDelegate
    {
        [Space, SerializeField] private EnhancedScroller scroller;
        [SerializeField] private EndlessCell cellPrefab;
        [SerializeField] private float cellSize = 200f;

        [Space, SerializeField] List<EndlessData> data = new();


        private void OnEnable()
        {
            scroller.Delegate = this;
        }

        public int GetNumberOfCells(EnhancedScroller scroller) => data.Count;

        public float GetCellViewSize(EnhancedScroller scroller, int dataIndex) => cellSize;

        public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
        {
            var cell = (EndlessCell)this.scroller.GetCellView(cellPrefab);

            cell.SetIndex(cellIndex);
            cell.SetData(data[dataIndex]);

            return cell;
        }
    }
}