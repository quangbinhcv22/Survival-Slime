using System.Collections.Generic;
using System.Linq;
using DataCore;
using EnhancedUI.EnhancedScroller;
using Plugins.QB_UI.Core;
using UnityEngine;

namespace UIFlow.Shop
{
    public class Sheet_Shop : Panel, IEnhancedScrollerDelegate
    {
        [Space] [SerializeField] private EnhancedScroller scroller;
        [SerializeField] private float cellSize = 900f;
        [SerializeField] private PurchasePacketCell packetCell;

        [Space] [Header("Fake Data")] 
        [SerializeField] private bool isFake;
        [SerializeField] private List<PurchaseFee> fakeDataList;
        [SerializeField] private PurchaseReward fakeReward;

        private readonly List<List<PurchaseFee>> _dataList = new();
        private PurchaseFee _fee;
        private PurchaseReward _reward;


        public void SetData(List<PurchaseFee> dataList)
        {
            _dataList.Clear();

            var list = new List<PurchaseFee>();
            list.AddRange(dataList);
            
            for (var i = 0; i < list.Count; i++)
            {
                if (list.Any() is false)
                    break;
                
                var listTemp = new List<PurchaseFee>();
                var type = list.First().type;
                
                for (var j = 0; j < list.Count; j++)
                {
                    if (list[j].type == type)
                    {
                        listTemp.Add(list[j]);
                        list.Remove(list[j]);
                        j--;
                    }
                }
                
                if(listTemp.Any())
                {
                    _dataList.Add(listTemp);
                    i = -1;
                }
            }

            scroller.Delegate = this;
        }

        public int GetNumberOfCells(EnhancedScroller scroller) => _dataList.Count;
        
        public float GetCellViewSize(EnhancedScroller scroller, int dataIndex) => cellSize;
        
        public EnhancedScrollerCellView GetCellView(EnhancedScroller curScroller, int dataIndex, int cellIndex)
        {
            var cell = (PurchasePacketCell)scroller.GetCellView(packetCell);
            cell.UpdateView(_dataList[dataIndex], PurchaseAction);
            
            return cell;
        }

        private void PurchaseAction(PurchaseFee fee)
        {
            // do something purchase clicked
            if (isFake)
            {
                _reward = fakeReward;
                Debug.Log($"Received purchase: {fee.fee.number}, {_reward.rewards.Count}");
            }
        }
        
        private void OnEnable()
        {
            if(isFake)
                SetData(fakeDataList);
        }
    }
}