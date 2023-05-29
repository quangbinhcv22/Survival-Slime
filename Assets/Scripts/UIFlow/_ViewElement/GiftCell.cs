using System;
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


        public Gift gtt;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) Binding(gtt);
        }


        private Gift _gift;

        public void Binding(Gift gift)
        {
            _gift = gift;

            icon.SetKey(_gift.IconAddress);
            txtAmount.SetText($"{_gift.number}");

            foreach (var signal in lockingSignals) signal.SetActive(_gift.state is GiftState.Locking);
            foreach (var signal in canClaimSignals) signal.SetActive(_gift.state is GiftState.CanClaim);
            foreach (var signal in claimedSignals) signal.SetActive(_gift.state is GiftState.Claimed);
        }
    }
}