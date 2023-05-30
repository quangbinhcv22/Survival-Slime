using DG.Tweening;
using UnityEngine;

namespace Gameplay.UX
{
    public class IdleAnim_Rect : MonoBehaviour
    {
        public float target = 1.25f;
        public float duration = 1.25f;
        public Ease ease = Ease.Linear;

        private Tween _tween;

        private RectTransform _rect;
        private Vector2 _startScale;
        private Vector2 _targetScale;

        private void Awake()
        {
            _rect = GetComponent<RectTransform>();
            _startScale = _rect.sizeDelta;
        }

        private void OnEnable()
        {
            _tween?.Kill();
            
            _rect.sizeDelta = _startScale;
            _targetScale = _startScale + new Vector2(0f, _startScale.y * target);

            _tween = _rect.DOSizeDelta(_targetScale, duration).SetEase(ease).SetLoops(-1, LoopType.Yoyo);
        }

        private void OnDisable()
        {
            _tween?.Kill();
        }
    }
}