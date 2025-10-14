using _Assets.Scripts.Services.UIs;
using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "UI Config", menuName = "Configs/UI")]
    public class UIConfig : ScriptableObject
    {
        [SerializeField] private WindowPresenter loadingWindowPresenter;
        public WindowPresenter LoadingWindowPresenter => loadingWindowPresenter;
        [SerializeField] private WindowPresenter mainWindowPresenter;
        public WindowPresenter MainWindowPresenter => mainWindowPresenter;
    }
}