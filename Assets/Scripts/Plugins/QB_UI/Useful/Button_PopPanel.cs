using Plugins.QB_UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Plugins.QB_UI.Useful
{
    [RequireComponent(typeof(Button))]
    public class Button_PopPanel : MonoBehaviour
    {
        private void Awake() => GetComponent<Button>().onClick.AddListener(OnClick);

        private void OnClick()
        {
            PanelContainer.Main.Pop();
        }
    }
}