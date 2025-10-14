using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Assets.Scripts.Services.UIs
{
    public class LoadingWindowView : WindowView
    {
        public override async UniTask Open(int sortingOrder)
        {
            await base.Open(sortingOrder);
            Debug.Log("OPEN LOADING WINDOW");
        }

        public override async UniTask Close()
        {
            await base.Close();
            Debug.Log("CLOSE LOADING WINDOW");
        }
    }
}