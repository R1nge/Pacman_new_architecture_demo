using UnityEngine;

namespace _Assets.Scripts.Services.UIs
{
    public abstract class WindowView : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private LoadingAnimation loadingAnimation;

        public virtual void Open(int sortingOrder)
        {
            canvas.sortingOrder = sortingOrder;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            //TODO: lerp canvas alpha
            canvasGroup.alpha = 1;
            StartLoadingAnimation();
        }

        public virtual void Close()
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            //TODO: lerp canvas alpha
            canvasGroup.alpha = 0;
            Dispose();
        }

        public virtual void RequestData()
        {
            StopLoadingAnimation();
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