using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Entity;
using UnityEngine;

namespace Gameplay.Utility
{
    public class EnemyDetector : MonoBehaviour
    {
        private readonly List<Enemy> _enemies = new();

        public Action<Enemy> OnEnter;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent<Enemy>(out var enemy))
            {
                _enemies.Add(enemy);
                OnEnter?.Invoke(enemy);
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.TryGetComponent<Enemy>(out var enemy))
            {
                _enemies.Remove(enemy);
            }
        }

        private void OnDisable()
        {
            _enemies.Clear();
        }

        public List<Enemy> Enemies
        {
            get
            {
                _enemies.RemoveAll(e => !e.gameObject.activeSelf);
                return _enemies.ToList();
            }
        }
    }
}