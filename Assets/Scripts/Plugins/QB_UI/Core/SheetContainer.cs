using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace Plugins.QB_UI.Core
{
    public class SheetContainer : PanelContainer
    {
        public List<SheetConfig> configs;
        public Toggle tgDefault;

        private void Awake()
        {
            foreach (var config in configs)
            {
                config.toggle.onValueChanged.AddListener(isOn => OnChanged(config.toggle, isOn));
            }
        }

        private void OnEnable()
        {
            if (tgDefault && !currents.Any())
            {
                tgDefault.isOn = true;
            }
            else
            {
                foreach (var config in configs)
                {
                    if(config.toggle.isOn) OnChanged(config.toggle, config.toggle.isOn);
                }
            }
        }

        private void OnChanged(Toggle toggle, bool isOn)
        {
            if (isOn)
            {
                Pop();

                foreach (var config in configs)
                {
                    if (config.toggle == toggle) Push(config.panelRef);
                    else config.toggle.isOn = false;
                }
            }
        }

        [Serializable]
        public class SheetConfig
        {
            public Toggle toggle;
            public AssetReference panelRef;
        }
    }
}