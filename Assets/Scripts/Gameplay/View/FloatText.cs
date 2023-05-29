using System;
using DG.Tweening;
using Gameplay.Enums;
using Gameplay.Pool;
using TMPro;
using UnityEngine;

namespace Gameplay.View
{
    public class FloatText : MonoBehaviour
    {
        public static void ShowAt(float damage, DamageType type, bool isCritical, Vector2 position)
        {
            string key = (type, isCritical) switch
            {
                (DamageType.Physical, false) => "text_damage_physic",
                (DamageType.Physical, true) => "text_damage_physic_crit",
                
                (DamageType.Magic, false) => "text_damage_magic",
                (DamageType.Magic, true) => "text_damage_magic_crit",
                
                (DamageType.True, false) => "text_damage_true",
                (DamageType.True, true) => "text_damage_true_crit",
                
                _ => throw new ArgumentOutOfRangeException()
            };
            
            Pooler.Get( key , t => t.GetComponent<FloatText>().Show(damage, position));
        }


        [SerializeField] private CanvasGroup group;
        [SerializeField] private TMP_Text text;

        [Space, SerializeField] private float yTarget = 0.25f;
        [SerializeField] private float floatDuration = 0.25f;
        [SerializeField] private Ease ease = Ease.OutQuad;

        [Space, SerializeField] private float alphaDuration = 0.25f;
    

        public void Show(float damage, Vector2 position)
        {
            text.SetText($"{damage:N0}");
            group.alpha = 1f;

            transform.position = position;
            transform.DOMoveY(position.y + yTarget, floatDuration).SetEase(ease).onComplete += () =>
            {
                group.DOFade(0f, alphaDuration).SetEase(ease).onComplete += () => gameObject.SetActive(false);
            };
        }
    }
}