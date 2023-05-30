using System.Collections.Generic;
using System.Linq;
using EnhancedUI.EnhancedScroller;
using Plugins.QB_UI.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace UIFlow.Collections.HeroCollection
{
    public class Sheet_PetCollection : Panel, IEnhancedScrollerDelegate
    {
        [Space] [SerializeField] private EnhancedScroller scroller;
        [SerializeField] private PetCollection_MasterCell prefab;
        [SerializeField] private int countPerCell = 4;
        [SerializeField] private float cellSize = 150f;

        [Space] public List<string> owned;

        private void OnEnable()
        {
            GameSelection.CollectionPet.Selected = owned.First();
            scroller.Delegate = this;
        }

        public int GetNumberOfCells(EnhancedScroller _)
        {
            return (int)Mathf.Ceil((float)owned.Count / countPerCell);
        }

        public float GetCellViewSize(EnhancedScroller scroller, int dataIndex) => cellSize;
        public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
        {
            var cell = (PetCollection_MasterCell) scroller.GetCellView(prefab);

            var startIndex = (dataIndex) * countPerCell;
            var endIndex = startIndex + countPerCell;
            var outRange = endIndex > owned.Count;
            var count = outRange ? countPerCell - (endIndex - owned.Count) : countPerCell;
            
            var slicedData = owned.GetRange(startIndex, count);
            
            cell.SetIndex(cellIndex);
            cell.SetData(slicedData);
            
            return cell;
        }
    }
}