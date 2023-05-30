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
        private NativeSize _nativeSize;

        public async void SetKey(string key)
        {
            _image ??= GetComponent<Image>();
            _nativeSize ??= GetComponent<NativeSize>();

            _image.sprite = await Addressables.LoadAssetAsync<Sprite>(key);
            if (_nativeSize) _nativeSize.Refresh();
        }
    }
}