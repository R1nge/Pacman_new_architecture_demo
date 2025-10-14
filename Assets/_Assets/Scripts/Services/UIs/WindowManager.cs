using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.UIs
{
    public class WindowManager : IInitializable
    {
        private Dictionary<WindowType, WindowPresenter> _loadedWindows;
        [Inject] private WindowFactory _windowFactory;


        public void Initialize()
        {
            _loadedWindows = new Dictionary<WindowType, WindowPresenter>();
        }

        public WindowPresenter Load(WindowType windowType)
        {
            var window = _windowFactory.GetWindow(windowType);
            _loadedWindows.TryAdd(windowType, window);
            return window;
        }

        public async UniTask Open(WindowType windowType)
        {
            await Open(windowType, 0);
        }

        public async UniTask Open(WindowType windowType, int millisecondsDelay)
        {
            var window = Load(windowType);

            if (millisecondsDelay != 0)
            {
                await UniTask.Delay(TimeSpan.FromMilliseconds(millisecondsDelay));
            }

            window.Order = _loadedWindows.Count;
            window.Open();
        }

        public async UniTask SwitchFromCurrentWindowTo(WindowType windowType)
        {
            Close(GetTopWindowType());
            await Open(windowType);
        }

        public void Close(WindowType windowType)
        {
            var hasWindow = _loadedWindows.TryGetValue(windowType, out var window);
            if (hasWindow)
            {
                window.Close();
                _loadedWindows.Remove(windowType);
            }
        }

        public void CloseTopWindow()
        {
            var topWindowType = GetTopWindowType();
            var topWindow = GetTopWindow();
            topWindow.Close();
            _loadedWindows.Remove(topWindowType);
        }

        public WindowPresenter GetTopWindow()
        {
            var windowOrder = -1;
            WindowPresenter windowView = null;
            foreach (var windowPair in _loadedWindows)
            {
                var top = windowPair.Value;
                var currentWindowOrder = top.Order;
                if (top.IsActive)
                {
                    if (currentWindowOrder > windowOrder)
                    {
                        windowOrder = currentWindowOrder;
                        windowView = top;
                    }
                }
            }

            return windowView;
        }

        public WindowType GetTopWindowType()
        {
            var windowOrder = -1;
            WindowType windowType = WindowType.None;
            foreach (var windowPair in _loadedWindows)
            {
                var topWindow = windowPair.Value;
                var topWindowType = windowPair.Key;
                var currentWindowOrder = topWindow.Order;
                if (topWindow.IsActive)
                {
                    if (currentWindowOrder > windowOrder)
                    {
                        windowOrder = currentWindowOrder;
                        windowType = topWindowType;
                    }
                }
            }

            return windowType;
        }

        public void HideAllWindows()
        {
            foreach (var windowsPair in _loadedWindows)
            {
                var window = windowsPair.Value;
                window.Close();
            }

            _loadedWindows.Clear();
        }
    }
}