using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Gameplay.Entity;
using Gameplay.Pool;
using UnityEngine;

namespace Gameplay.View
{
    public class HpBar_Enemy : MonoBehaviour
    {
        private static readonly Dictionary<Enemy, HpBar_Enemy> ShowingBars = new();
        private const float ShowDuration = 0.5f;
        private static readonly Vector3 ShowOffset = new Vector2(0, -0.85f);

        public static void Show(Enemy enemy)
        {
            if (ShowingBars.ContainsKey(enemy))
            {
                ShowingBars[enemy].Fill(enemy).Forget();
            }
            else
            {
                Pooler.Get("hp_bar_enemy", bObj =>
                {
                    if (ShowingBars.ContainsKey(enemy))
                    {
                        bObj.gameObject.SetActive(false);
                        return;
                    }
                    
                    var bar = bObj.GetComponent<HpBar_Enemy>();

                    ShowingBars.Add(enemy, bar);
                    bar.Fill(enemy).Forget();
                });
            }
        }


        [SerializeField] private Transform fill;

        [Space, SerializeField] private float minFill = -2f;
        private const float MaxFill = 0f;


        private CancellationTokenSource _cancellationSource;
        private Enemy _enemy;

        public async UniTaskVoid Fill(Enemy enemy)
        {
            _cancellationSource?.Cancel();

            _enemy = enemy;
            transform.SetParent(_enemy.transform);
            transform.localPosition = ShowOffset;


            var offset = minFill + ((MaxFill - minFill) * enemy.Stat.HpPercent);
            fill.localPosition = new Vector3(offset, 0f, 0f);

            _cancellationSource = new CancellationTokenSource();
            await UniTask.Delay(TimeSpan.FromSeconds(ShowDuration), cancellationToken: _cancellationSource.Token);
            
            transform.SetParent(Pooler.Main.transform);
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _cancellationSource = null;
            ShowingBars.Remove(_enemy);
        }
    }
}