using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace UIFlow.Collections
{
    public class UI_EntityModel : MonoBehaviour
    {
        private GameObject _model;

        public async void Load(string key)
        {
            if (_model) Destroy(_model);
            _model = await Addressables.InstantiateAsync(key, parent: transform);
        }
    }
}