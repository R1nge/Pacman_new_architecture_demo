using _Assets.Scripts.Services;
using _Assets.Scripts.Services.Models;
using Scellecs.Morpeh;
using VContainer;

namespace _Assets.Scripts.Ecs.Movement.Systems
{
    public class PacmanFieldScoreSystem : ISystem
    {
        [Inject] private MazeService mazeService;
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
            if (mazeService.GetCellType(positionX, positionY) == CellModel.CellType.Point)
            {
                mazeService.SetCellType(positionX, positionY, CellModel.CellType.None);
                _scoreService.Add(1);
                _ballSpawner.RemoveAt(_pacmanService.GetPacmanPosition());
            }
        }

        public void Dispose()
        {
        }
    }
}