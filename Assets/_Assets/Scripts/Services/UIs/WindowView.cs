using Cysharp.Threading.Tasks;
using R1ngeUtils;
using UnityEngine;

namespace _Assets.Scripts.Services.UIs
{
    public abstract class WindowView : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private LoadingAnimation loadingAnimation;
        [SerializeField] private float fadeDuration = 1;

        public virtual async UniTask Open(int sortingOrder)
        {
            canvas.sortingOrder = sortingOrder;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

            await foreach (var value in LerpUtils.LerpFloat(canvasGroup.alpha, 1, fadeDuration))
            {
                canvasGroup.alpha = value;
            }


            StartLoadingAnimation();
        }

        public virtual async UniTask Close()
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;

            await foreach (var value in LerpUtils.LerpFloat(canvasGroup.alpha, 0, fadeDuration))
            {
                canvasGroup.alpha = value;
            }

            Dispose();
        }

        public virtual void StartLoadingAnimation()
        {
            loadingAnimation.StartAnimation();
        }

        public virtual void StopLoadingAnimation()
        {
            loadingAnimation.StopAnimation();
        }

        public virtual void Dispose()
        {
            Destroy(gameObject);
        }
    }
}