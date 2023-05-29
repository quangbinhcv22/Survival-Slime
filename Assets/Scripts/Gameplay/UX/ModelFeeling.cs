using DG.Tweening;
using UnityEngine;

namespace Gameplay.UX
{
    public class ModelFeeling : MonoBehaviour
    {
        public void Feeling_OnDamage()
        {
            GetComponent<SpriteRenderer>().DOColor(new Color(1, 0.7803922f, 0.7803922f, 1f), 0.35f).onComplete += () =>
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            };
        }
    }
}