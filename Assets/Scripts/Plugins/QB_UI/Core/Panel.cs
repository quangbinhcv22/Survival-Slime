using System;
using UnityEditor;
using UnityEngine;

namespace Plugins.QB_UI.Core
{
    [DisallowMultipleComponent]
    public abstract partial class Panel : MonoBehaviour
    {
        public enum Action_OnOff
        {
            Cached = 0,
            Destroy = 1,
            Release = 2,
        }

        public Action_OnOff actionOnOff;


        public Action PushCompleted;
        public Action PopCompleted;

        [NonSerialized] public PanelContainer Container;


        public void OnPush()
        {
            gameObject.SetActive(true);
            PushCompleted?.Invoke();

            OnOpen();
        }

        public void OnPop()
        {
            OnClose();

            gameObject.SetActive(false);
            PopCompleted?.Invoke();
        }

        protected virtual void OnOpen()
        {
        }

        protected virtual void OnClose()
        {
        }

        private void OnValidate()
        {
#if UNITY_EDITOR
            name = KeyOf(GetType());
            EditorUtility.SetDirty(gameObject);
#endif
        }
    }

    public enum PanelType
    {
        Unknown = 0,

        Screen = 1,
        Popup = 2,
        Sheet = 3,
    }
}