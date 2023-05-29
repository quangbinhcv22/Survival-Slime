using System;
using UnityEngine;

namespace Gameplay.Progress
{
    [Serializable]
    public class LevelProgress
    {
        [Space] [SerializeField] private int level;
        [SerializeField] private int xpCurrent;
        [SerializeField] private int xpRequired;

        [Space] [SerializeField] private int xpBase = 1000;
        [SerializeField] private float xpCurve = 1.25f;


        public int Level => level;
        public int XpCurrent => xpCurrent;
        public int XpRequired => xpRequired;


        public Action OnLevelUp;
        public Action LevelChanged;
        public Action XpChanged;


        public void Reset() => SetLevel(1);


        public void AddXp(int xp)
        {
            Debug.Log(xp);

            xpCurrent += xp;
            XpChanged?.Invoke();

            CheckLevelUp();
        }

        private void CheckLevelUp()
        {
            if (xpCurrent >= xpRequired) LevelUp();
        }

        private void LevelUp()
        {
            OnLevelUp?.Invoke();

            xpCurrent -= xpRequired;

            SetLevel(level + 1);
            CheckLevelUp();
        }

        public void SetLevel(int lv)
        {
            level = lv;
            xpRequired = (int)(xpBase + xpCurve * (lv - 1));

            LevelChanged?.Invoke();
            XpChanged?.Invoke();
        }
    }
}