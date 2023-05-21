using DG.Tweening;
using UnityEngine;

public class IdleAnim : MonoBehaviour
{
    public float target = 1.25f;
    public float duration = 1.25f;
    public Ease ease = Ease.Linear;

    private void Start()
    {
        transform.DOScaleY(target, duration).SetEase(ease).SetLoops(-1, LoopType.Yoyo);
    }
}