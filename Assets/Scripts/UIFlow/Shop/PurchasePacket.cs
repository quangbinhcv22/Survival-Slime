using DataCore;
using TMPro;
using UIFlow._Reusable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIFlow.Shop
{
    public class PurchasePacket : MonoBehaviour
    {
        public int type;
        public int id;
        public Button button;
        public TMP_Text priceText;
        public AddressableImage icon;

        private PurchaseFee fee;


        public void UpdateView(PurchaseFee feePurchase, UnityAction<PurchaseFee> purchaseAction)
        {
            fee = feePurchase;
            priceText.SetText(feePurchase.fee.number.ToString());
            icon.SetKey(feePurchase.fee.IconAddress);
            button.onClick.AddListener(() =>
            {
                purchaseAction?.Invoke(fee);
            });
        }
    }
}
