using DG.Tweening;
using UnityEngine;

namespace Ui
{
    public class ProgressBar_Move : ProgressBar
    {
        [Space, SerializeField] private RectTransform _parent;
        private RectTransform _transform;

        private void Awake()
        {
            _transform = fill.GetComponent<RectTransform>();
        }

        protected override Tween Tweening(float value)
        {
            return _transform.DOLocalMoveX((value - 1) * _parent.sizeDelta.x, duration).SetEase(ease);
        }
    }
}