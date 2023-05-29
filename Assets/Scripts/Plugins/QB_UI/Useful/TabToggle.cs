using UnityEngine;
using UnityEngine.UI;

namespace Plugins.QB_UI.Useful
{
    [RequireComponent(typeof(Toggle), typeof(Image))]
    public class TabToggle : MonoBehaviour
    {
        [SerializeField] private Sprite onSprite;
        [SerializeField] private Sprite offSprite;

        private Image _image;
        private Toggle _toggle;

        protected virtual void Awake()
        {
            _image = GetComponent<Image>();

            _toggle = GetComponent<Toggle>();
            _toggle.onValueChanged.AddListener(OnChanged);
        }

        private void OnEnable()
        {
            OnChanged(_toggle.isOn);
        }

        protected virtual void OnChanged(bool isOn)
        {
            _image.sprite = isOn ? onSprite : offSprite;
            _toggle.interactable = !isOn;
        }

        private void OnValidate()
        {
            GetComponent<Image>().sprite = GetComponent<Toggle>().isOn ? onSprite : offSprite;
        }
    }
}