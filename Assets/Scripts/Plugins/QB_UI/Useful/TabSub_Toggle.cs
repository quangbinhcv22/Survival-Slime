using UnityEngine;

namespace Plugins.QB_UI.Useful
{
    public class TabSub_Toggle : TabToggle
    {
        [Space, SerializeField] private float onSize = 125f;
        [SerializeField] private float offSize = 100f;

        private RectTransform _rectTransform;

        protected override void Awake()
        {
            base.Awake();
            _rectTransform = GetComponent<RectTransform>();
        }

        protected override void OnChanged(bool isOn)
        {
            base.OnChanged(isOn);

            var size = _rectTransform.sizeDelta;
            size.y = isOn ? onSize : offSize;

            _rectTransform.sizeDelta = size;
        }
    }
}