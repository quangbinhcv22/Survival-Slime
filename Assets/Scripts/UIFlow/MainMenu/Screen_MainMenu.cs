using Plugins.QB_UI.Core;
using UnityEngine;

namespace UIFlow.MainMenu
{
    public class Screen_MainMenu : Panel, IBackHandler
    {
        public bool OnBack()
        {
            Debug.Log("No response!");
            return true;
        }
    }
}