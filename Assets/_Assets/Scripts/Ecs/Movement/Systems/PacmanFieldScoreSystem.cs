using _Assets.Scripts.Services;
using _Assets.Scripts.Services.Models;
using Scellecs.Morpeh;
using VContainer;

namespace _Assets.Scripts.Ecs.Movement.Systems
{
    public class PacmanFieldScoreSystem : ISystem
    {
        [Inject] private MapService _mapService;
        [Inject] private PacmanService _pacmanService;
        [Inject] private ScoreService _scoreService;
        [Inject] private BallSpawner _ballSpawner;
        public World World { get; set; }

        public void OnAwake()
        {
        }

        public void OnUpdate(float deltaTime)
        {
            var positionX = (int)_pacmanService.GetPacmanPosition().x;
            var positionY = (int)_pacmanService.GetPacmanPosition().y;
            if (_mapService.GetCellType(positionX, positionY) == CellModel.CellType.Point)
            {
                _mapService.SetCellType(positionX, positionY, CellModel.CellType.None);
                _scoreService.Add(1);
                _ballSpawner.RemoveAt(_pacmanService.GetPacmanPosition());
            }
        }

        public void Dispose()
        {
        }
    }
}