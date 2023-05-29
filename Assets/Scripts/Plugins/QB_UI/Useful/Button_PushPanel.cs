using Plugins.QB_UI.Core;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace Plugins.QB_UI.Useful
{
    [RequireComponent(typeof(Button))]
    public class Button_PushPanel : MonoBehaviour
    {
        [SerializeField] private AssetReference panelRef;
        private PanelContainer _container;

        private void Awake() => GetComponent<Button>().onClick.AddListener(OnClick);

        private void OnClick()
        {
            _container ??= PanelContainer.Of(gameObject);
            _container.Push(panelRef);
        }
    }
}