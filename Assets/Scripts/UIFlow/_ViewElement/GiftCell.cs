using DataCore;
using EnhancedUI.EnhancedScroller;
using TMPro;
using UIFlow._Reusable;
using UnityEngine;
using UnityEngine.UI;

namespace UIFlow._ViewElement
{
    public class GiftCell : EnhancedScrollerCellView
    {
        [Space, SerializeField] private AddressableImage icon;
        [SerializeField] private TMP_Text txtAmount;
        [SerializeField] private Button claim;

        [Space] [SerializeField] private GameObject[] lockingSignals;
        [SerializeField] private GameObject[] canClaimSignals;
        [SerializeField] private GameObject[] claimedSignals;
        [SerializeField] private GameObject[] unBuySignals;


        public Gift gtt;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) SetData(gtt);
        }


        private Gift _gift;

        public void SetData(Gift gift)
        {
            _gift = gift;

            icon.SetKey(_gift.IconAddress);
            txtAmount.SetText($"{_gift.number:N0}");

            foreach (var signal in lockingSignals) signal.SetActive(_gift.state is GiftState.Locking);
            foreach (var signal in canClaimSignals) signal.SetActive(_gift.state is GiftState.CanClaim);
            foreach (var signal in claimedSignals) signal.SetActive(_gift.state is GiftState.Claimed);
        }

        public void SetPurchase(bool bought)
        {
            foreach (var signal in unBuySignals) signal.SetActive(!bought);
        }
    }
}