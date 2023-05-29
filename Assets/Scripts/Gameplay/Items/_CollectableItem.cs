using DG.Tweening;
using Plugins.QB_Extensions;
using UnityEngine;

namespace Gameplay.Items
{
    public abstract class _CollectableItem : MonoBehaviour
    {
        public float tweenDuration = 0.5f;
        public Ease tweenEase = Ease.OutQuad;

        private BoxCollider2D _collider;
    
        public bool Usable { get; set; }
        public _ItemCollector Collector { get; set; }

        private void Awake()
        {
            _collider = GetComponent<BoxCollider2D>();
        }

        protected virtual void OnEnable()
        {
            Usable = true;
        }

        public void Collect(_ItemCollector collector, float timeScale = 1)
        {
            if (!Usable) return;

            Collector = collector;
            Usable = false;

            OnCollect_Begin();
        
            transform.DOMove(collector.transform, tweenDuration * timeScale).SetEase(tweenEase).onComplete += () =>
            {
                OnCollect_End();
                gameObject.SetActive(false);
            };
        }
    
        protected abstract void OnCollect_Begin();
        protected abstract void OnCollect_End();


        private void OnBecameVisible()
        {
            _collider.enabled = true;
        }

        private void OnBecameInvisible()
        {
            _collider.enabled = false;
        }
    }
}