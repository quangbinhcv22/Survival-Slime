using DG.Tweening;
using UnityEngine;

namespace Gameplay.UX
{
    public class IdleAnim : MonoBehaviour
    {
        public float target = 1.25f;
        public float duration = 1.25f;
        public Ease ease = Ease.Linear;

        private Tween _tween;

        private void OnBecameVisible()
        {
            _tween?.Kill();
            _tween = transform.DOScaleY(target, duration).SetEase(ease).SetLoops(-1, LoopType.Yoyo);
        }

        private void OnBecameInvisible()
        {
            _tween?.Kill();
        }
    }
}