using System;
using UnityEngine;

namespace Gameplay
{
    public class BattleM : MonoBehaviour
    {
        public static BattleM Main;
        
        [Space] public int time = 0;


        [SerializeField] private int level;

        public int Level
        {
            get => level;
            set
            {
                level = value;
                LevelChanged?.Invoke(value);
            }
        }

        public Action<int> LevelChanged;


        public int xpRequired = 1000;
        public int xpCurrent = 0;

        public void OnXp()
        {
        }


        public Action<int, int> XpChanged;
        public Action<int> TimeChanged;

        private void SetLevel(int level)
        {
        }

        public void StartBattle()
        {
            SetLevel(1);
        }

        private void OnEnable()
        {
            Main = this;
        }
    }
}