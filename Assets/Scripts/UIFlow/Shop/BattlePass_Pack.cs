using System.Collections.Generic;
using DataCore;
using EnhancedUI.EnhancedScroller;
using UIFlow._ViewElement;
using UnityEngine;

namespace UIFlow.Shop
{
    public class BattlePass_Pack : MonoBehaviour, IEnhancedScrollerDelegate
    {
        [Space, SerializeField] private EnhancedScroller scroller;
        [SerializeField] private GiftCell cellPrefab;
        [SerializeField] private float cellSize = 200f;

        [Space, SerializeField] List<Gift> data = new();

        
        public float scrollPosition = 0;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                scroller.ScrollPosition = scrollPosition;
            }
        }

        void OnEnable()
        {
            SetData(data);
        }

        public void SetData(List<Gift> pack)
        {
            data = pack;
            scroller.Delegate = this;
        }

        public int GetNumberOfCells(EnhancedScroller scroller) => data.Count;

        public float GetCellViewSize(EnhancedScroller scroller, int dataIndex) => cellSize;

        public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
        {
            var cell = (GiftCell)scroller.GetCellView(cellPrefab);

            data[dataIndex].number = dataIndex;
            cell.SetData(data[dataIndex]);

            return cell;
        }
    }
}