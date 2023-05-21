using DG.Tweening;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public float distance = 1.3f;
    public float duration = 1;
    public Ease ease;

    void Start()
    {
        transform.DOLocalMoveX(-distance, 0f);
        transform.DOLocalMoveX(distance, duration).SetEase(ease).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
    }
}