using System.Collections.Generic;
using DataCore;
using EnhancedUI.EnhancedScroller;
using Plugins.QB_UI.Core;
using UIFlow._ViewElement;
using UnityEngine;

namespace UIFlow.Shop
{
    public class Screen_BattlePass : Panel
    {
        public List<Gift> freePack;
        public List<Gift> vipPack;
        public List<Gift> premiumPack;
    }

    public class BattlePass_Pack : MonoBehaviour, IEnhancedScrollerDelegate
    {
        [Space, SerializeField] private EnhancedScroller scroller;
        [SerializeField] private GiftCell cellPrefab;
        [SerializeField] private float cellSize = 200f;

        [Space, SerializeField] List<Gift> data = new();


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

            return cell;
        }
    }
}