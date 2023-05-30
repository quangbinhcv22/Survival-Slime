using System.Collections.Generic;
using UIFlow._Reusable;
using UnityEngine;

namespace UIFlow.Collections.HeroCollection
{
    public class PetCollection_MasterCell : CellView_IndexColor
    {
        [SerializeField] private PetCollection_Cell[] cells;

        public void SetData(List<string> data)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if (i >= data.Count)
                {
                    cells[i].SetVisible(false);
                }
                else
                {
                    cells[i].SetVisible(true);
                    cells[i].SetData(PlayerData_Query.PetOf(data[i]));
                }
            }
        }
    }
}