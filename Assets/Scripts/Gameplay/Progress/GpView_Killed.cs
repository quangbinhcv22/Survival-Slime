using TMPro;
using UnityEngine;

namespace Gameplay.Progress
{
    [RequireComponent(typeof(TMP_Text))]
    public class GpView_Killed : MonoBehaviour
    {
        private TMP_Text _txt;

        private void Awake()
        {
            _txt = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            BattleM.Main.onStatisticKilled += OnChanged;
            OnChanged();
        }
        
        private void OnDisable()
        {
            BattleM.Main.onStatisticKilled -= OnChanged;
        }

        private void OnChanged()
        {
            _txt.SetText($"{BattleM.Main.Killed:N0}");
        }
    }
}