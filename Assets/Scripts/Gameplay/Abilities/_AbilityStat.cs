using System;
using Gameplay.Enums;
using UnityEngine;

namespace Gameplay.Abilities
{
    [Serializable]
    public class _AbilityStat
    {
        public const float PlayerDamage = 100;

        
        [Header("Time")] [SerializeField] private float duration = 3f;
        [SerializeField] private float cooldown = 3f;
        [SerializeField] private float interval = 0f;
        [SerializeField] private float speed = 1f;

        [Header("Other")] [SerializeField] private float damage = 1f;
        [SerializeField] private int amount = 1;
        [SerializeField] private float size = 1;
        [SerializeField] private float range = 5;

        [Space] public DamageType damageType;

        public float Duration => duration;
        public float Cooldown => cooldown;
        public float Interval => interval;
        public float Speed => speed;
        public float Range => range;
        public float Damage => damage * PlayerDamage;
        public int Amount => amount;
        public float Size => size;
    }
}