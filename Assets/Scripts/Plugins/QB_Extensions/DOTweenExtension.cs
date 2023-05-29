using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace Plugins.QB_Extensions
{
    public static class DOTweenExtension
    {
        public static TweenerCore<Vector3, Vector3, VectorOptions> DOMove(this Transform target, Transform endValue, float duration, bool snapping = false)
        {
            var t = DOTween.To(() => target.position, x => target.position = x, endValue.position, duration);
            t.SetOptions(snapping).SetTarget(target);
            return t;
        }
    }
}