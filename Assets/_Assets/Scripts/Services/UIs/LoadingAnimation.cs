using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Assets.Scripts.Services.UIs
{
    public class LoadingAnimation : MonoBehaviour
    {
        [SerializeField] private float fadeDuration = 1f;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private float delay;
        protected bool IsStarted;
        protected float TimeSinceOpen;

        public virtual void Update()
        {
            TimeSinceOpen = Math.Clamp(TimeSinceOpen + Time.deltaTime, 0, delay + 1);
            if (IsStarted)
            {
                if (TimeSinceOpen >= delay)
                {
                    Show();
                    IsStarted = false;
                }
            }
        }

        public virtual void StartAnimation()
        {
            IsStarted = true;
        }

        public virtual async void Show()
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            /*
            await foreach (var value in LerpUtils.LerpFloat(canvasGroup.alpha, 1, fadeDuration))
            {
                canvasGroup.alpha = value;
            }
            */
        }

        public virtual async UniTask Hide()
        {
            /*
            await foreach (var value in LerpUtils.LerpFloat(canvasGroup.alpha, 0, fadeDuration))
            {
                canvasGroup.alpha = value;
            }
*/
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

        public virtual async void StopAnimation()
        {
            IsStarted = false;
            TimeSinceOpen = 0;
            await Hide();
        }
    }
}