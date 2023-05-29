using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using Gameplay.Abilities;
using Plugins.QB_Extensions;
using Plugins.QB_UI.Core;
using UnityEngine;

namespace Gameplay.Bullets
{
    public class _Bullet : MonoBehaviour
    {
        [Space, SerializeField] private bool destroyOnInvisible = true;
        [SerializeField] private bool destroyOnCollision = true;
        [SerializeField] private float delayDestroy = 0f;

        protected _Ability owner;
        protected _AbilityStat stat;
        private Transform _root;
        protected Vector3 startPos;
        protected Vector3 dir;
        
        protected Transform root;
        protected Transform cachedTrans;

        private void Awake()
        {
            cachedTrans = transform;
        }


        public virtual void Shoot(_Ability shooter, Vector3 startPosition, Vector3 direction)
        {
            owner = shooter;
            stat = shooter.stat;
            startPos = startPosition;
            dir = direction;
            root = shooter.transform;


            SetUpShoot();
        }

        protected virtual void SetUpShoot()
        {
            cachedTrans.position = startPos;
            cachedTrans.LookAt2D(startPos + dir);
        }

        protected virtual void Update()
        {
            cachedTrans.position += dir * (stat.Speed * Time.deltaTime);

            if ((startPos - cachedTrans.position).magnitude >= stat.Range)
            {
                gameObject.SetActive(false);
            }
        }

        protected virtual void OnBecameInvisible()
        {
            if (destroyOnInvisible) ReturnPool();
        }

        protected virtual async void OnTriggerEnter2D(Collider2D col)
        {
            if (owner.OnTrigger(col, gameObject) && destroyOnCollision)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(delayDestroy));
                ReturnPool();
            }
        }

        protected virtual void ReturnPool()
        {
            gameObject.SetActive(false);
        }
        
        private void OnValidate()
        {
            name = GetType().ToString().Split(".").Last().Pascal_ToSnake();
        }
    }
}