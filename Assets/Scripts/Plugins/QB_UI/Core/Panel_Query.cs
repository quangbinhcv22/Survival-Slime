using System;
using System.Linq;
using UnityEngine;

namespace Plugins.QB_UI.Core
{
    public partial class Panel : MonoBehaviour
    {
        public static PanelType TypeOf<T>()
        {
            return TypeOf(KeyOf<T>());
        }

        public static PanelType TypeOf(string key)
        {
            return key.Split("_").First() switch
            {
                "screen" => PanelType.Screen,
                "popup" => PanelType.Popup,
                "sheet" => PanelType.Sheet,
                _ => PanelType.Unknown,
            };
        }

        public static string KeyOf<T>() => KeyOf(typeof(T));
        public static string KeyOf(Type type) => type.ToString().Split(".").Last().Pascal_ToSnake();

        public static bool ValidKey(string key) => TypeOf(key) is not PanelType.Unknown;
    }
}