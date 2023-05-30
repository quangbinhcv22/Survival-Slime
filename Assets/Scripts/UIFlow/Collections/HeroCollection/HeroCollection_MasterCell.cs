using System.Collections.Generic;
using UIFlow._Reusable;
using UnityEngine;

namespace UIFlow.Collections.HeroCollection
{
    public class HeroCollection_MasterCell : CellView_IndexColor
    {
        [SerializeField] private List<HeroCollection_Cell> cells;

        public void SetData(List<string> data)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                if (i >= data.Count)
                {
                    cells[i].SetVisible(false);
                }
                else
                {
                    cells[i].SetVisible(true);
                    cells[i].SetData(PlayerData_Query.HeroOf(data[i]));
                }
            }
        }
    }
}