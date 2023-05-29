using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using Gameplay.Entity;
using Plugins.QB_UI.Core;
using UnityEngine;

namespace Gameplay.Abilities
{
    [RequireComponent(typeof(_AbilityAudio))]
    public abstract class _Ability : MonoBehaviour
    {
        public _AbilityStat stat;
        
        protected new _AbilityAudio audio;


        private async void Start()
        {
            audio = GetComponent<_AbilityAudio>();
            
            Init();
            
            await UniTask.Delay(TimeSpan.FromSeconds(stat.Cooldown * 0.5f));
            OnDuration();
        }

        protected bool isDuration;

        private async void OnDuration()
        {
            isDuration = true;

            audio.OnExecute();
            Execute();
            OnInterval();

            await UniTask.Delay(TimeSpan.FromSeconds(stat.Duration));
            OnCooldown();
        }

        private async void OnInterval()
        {
            if (stat.Interval <= 0 || !isDuration) return;

            audio.OnInterval();
            Interval();

            await UniTask.Delay(TimeSpan.FromSeconds(stat.Interval));
            OnInterval();
        }

        private async void OnCooldown()
        {
            audio.OnUnExecute();
            UnExecute();

            await UniTask.Delay(TimeSpan.FromSeconds(stat.Cooldown));
            OnDuration();
        }


        protected abstract void Init();
        protected abstract void Execute();
        protected abstract void Interval();
        protected abstract void UnExecute();


        private void OnValidate()
        {
            name = GetType().ToString().Split(".").Last().Pascal_ToSnake();
        }

        
        public virtual bool OnTrigger(Collider2D col, GameObject bullet)
        {
            if (col.TryGetComponent<Enemy>(out var enemy))
            {
                TakeDamage(enemy);
            }

            return true;
        }

        protected virtual void TakeDamage(Enemy enemy)
        {
            enemy.OnDamaged(stat.Damage, stat.damageType);
            audio.OnHit();
        }
    }
}