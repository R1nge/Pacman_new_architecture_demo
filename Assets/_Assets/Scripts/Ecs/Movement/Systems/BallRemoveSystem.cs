using _Assets.Scripts.Services;
using _Assets.Scripts.Services.Models;
using Scellecs.Morpeh;
using VContainer;

namespace _Assets.Scripts.Ecs.Movement.Systems
{
    public class BallRemoveSystem : ISystem
    {
        [Inject] private MazeService _mazeService;
        [Inject] private BallSpawner _ballSpawner;
        [Inject] private PacmanService _pacmanService;
        public World World { get; set; }

        public void OnAwake()
        {
        }

        public void OnUpdate(float deltaTime)
        {
            var positionX = (int)_pacmanService.GetPacmanPosition().x;
            var positionY = (int)_pacmanService.GetPacmanPosition().y;
            if (_mazeService.GetCellType(positionX, positionY) == CellModel.CellType.Point)
            {
                _mazeService.SetCellType(positionX, positionY, CellModel.CellType.None);
                _ballSpawner.RemoveAt(_pacmanService.GetPacmanPosition());
            }
        }

        public void Dispose()
        {
        }
    }
}