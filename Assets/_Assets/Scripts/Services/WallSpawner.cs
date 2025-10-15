using _Assets.Scripts.Configs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services
{
    public class WallSpawner
    {
        [Inject] private IObjectResolver _objectResolver;
        [Inject] private ConfigProvider _configProvider;

        public GameObject Create(Vector3 position)
        {
            return _objectResolver.Instantiate(_configProvider.Wall, position, Quaternion.identity);
        }
    }
}