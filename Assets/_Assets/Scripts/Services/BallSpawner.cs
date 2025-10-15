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
        private GameObject[,] _balls = new GameObject[31, 28];

        public GameObject Create(Vector3 position)
        {
            var ball = _objectResolver.Instantiate(_configProvider.Point, position, Quaternion.identity);
            _balls[(int)position.x, (int)position.y] = ball;
            return ball;
        }

        public void RemoveAt(Vector3 position)
        {
            if (_balls[(int)position.x, (int)position.y] != null)
            {
                Object.Destroy(_balls[(int)position.x, (int)position.y].gameObject);
            }
        }
    }
}