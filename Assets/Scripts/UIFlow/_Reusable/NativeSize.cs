using UnityEngine;
using UnityEngine.UI;

namespace UIFlow._Reusable
{
    public class NativeSize : MonoBehaviour
    {
        private Image _image;

        private RectTransform _rect;
        private Vector2 _startSize;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _rect = GetComponent<RectTransform>();
            _startSize = _rect.sizeDelta;
        }

        public void Refresh()
        {
            var spriteSize = _image.sprite.textureRect.size;
            var scale = Mathf.Max(spriteSize.x / _startSize.x, spriteSize.y / _startSize.y);

            _rect.sizeDelta = spriteSize / scale;
        }
    }
}