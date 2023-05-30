using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace UIFlow.Collections.HeroCollection
{
    public class SizeAdobe : MonoBehaviour
    {
        public Vector2 size;
        public Vector2 output;

        private void OnValidate()
        {
            output = new Vector2(Mathf.Ceil(Mathf.CeilToInt(size.x) / 4f) * 4 - 1, Mathf.Ceil(Mathf.CeilToInt(size.y) / 4f) * 4 - 1);
        }
    }
}