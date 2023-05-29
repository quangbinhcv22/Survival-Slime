using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace UIFlow._Reusable
{
    public class CellView_IndexColor : EnhancedScrollerCellView
    {
        [Space, SerializeField] private Image bg;
        [SerializeField] private Color clOdd = new(0.4627451f, 0.5843138f, 0.6941177f, 1f);
        [SerializeField] private Color clEven = new(0.3882353f, 0.5058824f, 0.6156863f, 1f);
        
        public void SetIndex(int index)
        {
            bg.color = index % 2 == 0 ? clEven : clOdd;
        }
    }
}