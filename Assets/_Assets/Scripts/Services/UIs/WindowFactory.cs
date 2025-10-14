using System;
using _Assets.Scripts.Configs;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.UIs
{
    public class WindowFactory
    {
        [Inject] private ConfigProvider _configProvider;
        [Inject] private IObjectResolver _objectResolver;

        public WindowPresenter GetWindow(WindowType windowType)
        {
            switch (windowType)
            {
                case WindowType.None:
                    break;
                case WindowType.Loading:
                    return _objectResolver.Instantiate(_configProvider.UIConfig.LoadingWindowPresenter);
                case WindowType.Main:
                    return _objectResolver.Instantiate(_configProvider.UIConfig.MainWindowPresenter);
                default:
                    throw new ArgumentOutOfRangeException(nameof(windowType), windowType, null);
            }

            return null;
        }
    }
}