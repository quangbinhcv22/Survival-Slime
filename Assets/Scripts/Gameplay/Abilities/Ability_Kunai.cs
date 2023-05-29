using Gameplay.Bullets;
using Gameplay.Control;
using Gameplay.Entity;
using Gameplay.Pool;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Gameplay.Abilities
{
    public class Ability_Kunai : _Ability
    {
        public AssetReference bulletRef;

        protected override void Init()
        {
        }

        protected override void Execute()
        {
            Pooler.Get(bulletRef,
                bullet => bullet.GetComponent<_Bullet>().Shoot(this, transform.position, MoveController.Direction));
        }

        protected override void Interval()
        {
        }

        protected override void UnExecute()
        {
        }
    }
}