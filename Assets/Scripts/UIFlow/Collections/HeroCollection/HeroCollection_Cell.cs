using EnhancedUI.EnhancedScroller;
using TMPro;
using UIFlow._Reusable;
using UnityEngine;
using UnityEngine.UI;

namespace UIFlow.Collections.HeroCollection
{
    [RequireComponent(typeof(CanvasGroup))]
    public class HeroCollection_Cell : EnhancedScrollerCellView
    {
        [Space] [SerializeField] private AddressableImage icon;
        [SerializeField] private TMP_Text txtLevel;

        [Space, SerializeField] private Button button;
        [SerializeField] private GameObject selectedSignal;

        private CanvasGroup _canvas;
        

        private HeroData _data;

        private void Awake()
        {
            _canvas ??= GetComponent<CanvasGroup>();
            button.onClick.AddListener(Select);
        }

        private void OnEnable()
        {
            GameSelection.CollectionHero.onSelect += OnOtherSelect;
        }
        
        private void OnDisable()
        {
            GameSelection.CollectionHero.onSelect -= OnOtherSelect;
        }

        private void OnOtherSelect(string id)
        {
            var selected = _data != null && id == _data.id;
            selectedSignal.SetActive(selected);
        }

        public void SetData(HeroData data)
        {
            _data = data;
            
            icon.SetKey(data.Address_Sprite);
            txtLevel.SetText($"{data.level:N0}");

            OnOtherSelect(GameSelection.CollectionHero.Selected);
        }

        public void Select()
        {
            GameSelection.CollectionHero.Selected = _data.id;
        }

        public void SetVisible(bool visible)
        {
            _canvas.alpha = visible ? 1 : 0f;
            _canvas.interactable = visible;
        }
    }
}