using UnityEngine;

namespace Gameplay.Items
{
    public class _ItemCollector : MonoBehaviour
    {
        public static _ItemCollector Main;

        private void OnEnable()
        {
            Main = this;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            var item = col.GetComponent<_CollectableItem>();
            item.Collect(this);
        }
    }
}