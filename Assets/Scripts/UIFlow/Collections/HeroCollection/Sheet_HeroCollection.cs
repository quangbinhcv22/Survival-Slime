using System.Collections.Generic;
using System.Linq;
using EnhancedUI.EnhancedScroller;
using Plugins.QB_UI.Core;
using UnityEngine;

namespace UIFlow.Collections.HeroCollection
{
    public class Sheet_HeroCollection : Panel, IEnhancedScrollerDelegate
    {
        [Space] [SerializeField] private EnhancedScroller scroller;
        [SerializeField] private HeroCollection_MasterCell prefab;
        [SerializeField] private int countPerCell = 4;
        [SerializeField] private float cellSize = 150f;

        [Space] public List<string> ownedHeroes;

        private void OnEnable()
        {
            GameSelection.CollectionHero.Selected = ownedHeroes.First();
            scroller.Delegate = this;
        }

        public int GetNumberOfCells(EnhancedScroller _)
        {
            return (int)Mathf.Ceil((float)ownedHeroes.Count / countPerCell);
        }

        public float GetCellViewSize(EnhancedScroller scroller, int dataIndex) => cellSize;
        public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
        {
            var cell = (HeroCollection_MasterCell) scroller.GetCellView(prefab);

            var startIndex = (dataIndex) * countPerCell;
            var endIndex = startIndex + countPerCell;
            var outRange = endIndex > ownedHeroes.Count;
            var count = outRange ? countPerCell - (endIndex - ownedHeroes.Count) : countPerCell;
            
            var slicedData = ownedHeroes.GetRange(startIndex, count);
            
            cell.SetIndex(cellIndex);
            cell.SetData(slicedData);
            
            return cell;
        }
    }
}