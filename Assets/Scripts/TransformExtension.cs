using UnityEngine;

public static class TransformExtension
{
    public static void Flip(this Transform transform, Vector2 direction)
    {
        var directionSign = Mathf.Sign(direction.x);
        if ((int)directionSign == (int)Mathf.Sign(transform.localScale.x)) return;

        var newScale = transform.localScale;
        newScale.x = Mathf.Abs(newScale.x) * Mathf.Sign(direction.x);

        transform.localScale = newScale;
    }
}