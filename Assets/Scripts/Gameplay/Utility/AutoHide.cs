using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay.Utility
{
    public class AutoHide : MonoBehaviour
    {
        [SerializeField] private int milliseconds = 750;
    
        private async void OnEnable()
        {
            await UniTask.Delay(milliseconds);
            gameObject.SetActive(false);
        }
    }
}