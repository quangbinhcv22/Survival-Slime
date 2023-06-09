using System.Collections.Generic;
using System.Linq;
using DataCore;
using EnhancedUI.EnhancedScroller;
using TMPro;
using UIFlow.Shop;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PurchasePacketCell : EnhancedScrollerCellView
{
    [SerializeField] private GridLayoutGroup gridLayoutGroup;
    [SerializeField] private Transform container;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private List<PurchasePacket> packets;
    [SerializeField] private List<PacketInfo> packetInfos;
    [SerializeField] private List<TitleForType> titleForTypes;

    private readonly List<PurchasePacket> _children = new();
    
    
    public void UpdateView(List<PurchaseFee> fees, UnityAction<PurchaseFee> purchaseAction)
    {
        DestroyAll();
        
        var title = titleForTypes.Find(item => item.type == fees.First().type);
        var info = packetInfos.Find(item => item.type == fees.First().type);
        
        gridLayoutGroup.cellSize = info.size;
        
        titleText.SetText(title.content);

        foreach (var fee in fees)
        {
            var childPrefab = packets.Find(item => item.id == fee.id);
            if (childPrefab != null)
            {
                _children.Add(Instantiate(childPrefab, container));
                _children.Last().UpdateView(fee, purchaseAction);
            }
        }
    }

    private void DestroyAll()
    {
        for (int i = 0; i < _children.Count; i++)
        {
            _children[i].gameObject.SetActive(false);
            Destroy(_children[i].gameObject, 0.5f);
            _children.Remove(_children[i]);
            i--;
        }
    }
}

[System.Serializable]
public class PacketInfo
{
    public int type;
    public Vector2 size;
}

[System.Serializable]
public class TitleForType
{
    public int type;
    public string content;
}
