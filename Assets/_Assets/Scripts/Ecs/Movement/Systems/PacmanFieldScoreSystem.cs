using _Assets.Scripts.Services;
using _Assets.Scripts.Services.Models;
using Scellecs.Morpeh;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using VContainer;

namespace _Assets.Scripts.Ecs.Movement.Systems
{
    public class PacmanFieldScoreSystem : ISystem
    {
        [Inject] private GridModel _mapModel;
        [Inject] private PacmanMoveModel _pacmanMoveModel;
        [Inject] private ScoreModel _scoreModel;
        [Inject] private BallSpawner _ballSpawner;
        public World World { get; set; }

        public void OnAwake()
        {
        }

        public void OnUpdate(float deltaTime)
        {
            var positionX = _pacmanMoveModel.CurrentPosition.CurrentValue.x;
            var positionY = _pacmanMoveModel.CurrentPosition.CurrentValue.y;
            if (_mapModel._cells[(int)positionX, (int)positionY].cellType.CurrentValue == CellModel.CellType.Point)
            {
                _mapModel._cells[(int)positionX, (int)positionY].cellType.Value = CellModel.CellType.None;
                _scoreModel.CurrentScore.Value += 1;
                _ballSpawner.RemoveAt(_pacmanMoveModel.CurrentPosition.CurrentValue);
                Debug.Log($"Added score; current score: {_scoreModel.CurrentScore.CurrentValue}");
            }
        }

        public void Dispose()
        {
        }
    }
}