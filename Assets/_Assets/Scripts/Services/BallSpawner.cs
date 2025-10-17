using System.Collections.Generic;
using _Assets.Scripts.Configs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services
{
    public class BallSpawner
    {
        [Inject] private IObjectResolver _objectResolver;
        [Inject] private ConfigProvider _configProvider;
        private GameObject[,] _balls;
        private int _ballCount;

        public GameObject Create(Vector3 position)
        {
            if (_balls == null || _balls.GetLength(0) != _configProvider.GameConfig.Width ||
                _balls.GetLength(1) != _configProvider.GameConfig.Height)
            {
                _balls = new GameObject[_configProvider.GameConfig.Width, _configProvider.GameConfig.Height];
            }

            var ball = _objectResolver.Instantiate(_configProvider.GameConfig.Point, position, Quaternion.identity);
            _balls[(int)position.x, (int)position.y] = ball;
            _ballCount++;
            return ball;
        }

        public void RemoveAt(Vector3 position)
        {
            if (_balls[(int)position.x, (int)position.y] != null)
            {
                Object.Destroy(_balls[(int)position.x, (int)position.y].gameObject);
                _ballCount--;
            }
        }

        public bool HasBall() => _ballCount > 0;
    }
}