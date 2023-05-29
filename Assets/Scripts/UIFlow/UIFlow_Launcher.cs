using System;
using Plugins.QB_UI.Core;
using UIFlow.MainMenu;
using UnityEngine;

namespace UIFlow
{
    [RequireComponent(typeof(PanelContainer))]
    public class UIFlow_Launcher : MonoBehaviour
    {
        private PanelContainer _container;

        private void Awake()
        {
            _container = GetComponent<PanelContainer>();
        }

        private void OnEnable()
        {
            _container.Push<Screen_MainMenu>();
            PanelContainer.Main = _container;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _container.Pop();
            }
        }
    }
}