using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Plugins.QB_UI.Core
{
    public class PanelContainer : MonoBehaviour
    {
        public static PanelContainer Of(GameObject child) => child.GetComponentInParent<PanelContainer>();
        public static PanelContainer Main;

        [NonReorderable] public List<Panel> currents = new();
        [NonReorderable] public List<Panel> pool = new();


        private static readonly Dictionary<string, string> _addressGuids = new();

        public T Push<T>() where T : Panel => (T)Push(Panel.KeyOf<T>());

        public Panel Push(AssetReference panelRef) => Push(panelRef.RuntimeKey.ToString());

        public virtual Panel Push(string key)
        {
            if (!Panel.ValidKey(key) && _addressGuids.ContainsKey(key)) key = _addressGuids[key];
            var panel = pool.FirstOrDefault(p => p.name == key);

            if (panel == null)
            {
                var panelGO = Addressables.InstantiateAsync(key, transform).WaitForCompletion();

                panel = panelGO.GetComponent<Panel>();
                panel.name = Panel.KeyOf(panel.GetType());
                panel.Container = this;

                if (!Panel.ValidKey(key))
                {
                    _addressGuids.Add(key, panel.name);
                    key = panel.name;
                }

                pool.Add(panel);

                if (Panel.TypeOf(key) is PanelType.Popup)
                {
                    var backdrop = Addressables.InstantiateAsync("backdrop", panel.transform).WaitForCompletion();
                    backdrop.transform.SetAsFirstSibling();
                }
            }

            if (!currents.Contains(panel)) currents.Add(panel);

            panel.transform.SetAsLastSibling();
            panel.OnPush();


            return panel;
        }


        public virtual void Pop()
        {
            if (!currents.Any()) return;

            var above = currents.Last();

            var backHandler = above.GetComponent<IBackHandler>();
            if (backHandler != null && !backHandler.OnBack()) return;

            currents.Remove(above);

            if (above.actionOnOff is not Panel.Action_OnOff.Cached)
            {
                above.PopCompleted += () =>
                {
                    pool.Remove(above);

                    switch (above.actionOnOff)
                    {
                        case Panel.Action_OnOff.Destroy:
                            Destroy(above.gameObject);
                            break;
                        case Panel.Action_OnOff.Release:
                            Addressables.ReleaseInstance(above.gameObject);
                            break;
                    }
                };
            }


            above.OnPop();
        }
    }
}