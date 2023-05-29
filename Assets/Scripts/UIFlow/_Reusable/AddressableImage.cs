using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace UIFlow._Reusable
{
    [RequireComponent(typeof(Image))]
    public class AddressableImage : MonoBehaviour
    {
        private Image _image;

        public async void SetKey(string key)
        {
            _image ??= GetComponent<Image>();
            _image.sprite = await Addressables.LoadAssetAsync<Sprite>(key);
        }
    }
}