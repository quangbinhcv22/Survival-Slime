using Gameplay.Entity;
using UnityEngine;

namespace Gameplay.View
{
    public class HpBar_Player : MonoBehaviour
    {
        [SerializeField] private Transform fill;
        [SerializeField] private float minFill = -2f;
        private const float MaxFill = 0f;

    
        private Player _entity;
    
        public void Reflect(Player entity)
        {
            _entity = entity;
            _entity.OnChanged_Hp += UpdateFill;

            UpdateFill();
        }
    
        public void UpdateFill()
        {
            var offset = minFill + ((MaxFill - minFill) * _entity.Stat.HpPercent);
            fill.localPosition = new Vector3(offset, 0f, 0f);
        }
    }
}