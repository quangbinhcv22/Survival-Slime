using Plugins.QB_UI.Core;
using UIFlow.MainMenu;
using UnityEngine;
using UnityEngine.UI;

namespace UIFlow.Battle
{
    public class Sheet_Campaign : Panel
    {
        [SerializeField] private Button btnStart;


        private void Awake()
        {
            btnStart.onClick.AddListener(() => { FindObjectOfType<Screen_MainMenu>().gameObject.SetActive(false); });
        }
    }
}