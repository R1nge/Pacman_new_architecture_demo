using _Assets.Scripts.Ecs;
using _Assets.Scripts.Services.Models;
using _Assets.Scripts.Services.UIs;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class GameState : IAsyncState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly WallSpawner _wallSpawner;
        private readonly GridModel _map;
        private readonly WindowManager _windowManager;
        private readonly BallSpawner _ballSpawner;
        private readonly MazeParser _mazeParser;
        private readonly InjectableInstaller _injectableInstaller;

        public GameState(GameStateMachine stateMachine, WallSpawner wallSpawner, GridModel map,
            WindowManager windowManager, BallSpawner ballSpawner, MazeParser mazeParser, InjectableInstaller injectableInstaller)
        {
            _stateMachine = stateMachine;
            _wallSpawner = wallSpawner;
            _map = map;
            _windowManager = windowManager;
            _ballSpawner = ballSpawner;
            _mazeParser = mazeParser;
            _injectableInstaller = injectableInstaller;
        }

        public async UniTask Enter()
        {
            await _windowManager.SwitchFromCurrentWindowTo(WindowType.Main);
            //TODO: move to root
            _map.InitializeMaze(_mazeParser.Parse());
            //
            _injectableInstaller.Init();
            for (int y = 0; y < _map._height; y++)
            {
                for (int x = 0; x < _map._width; x++)
                {
                    if (_map._cells[x, y].cellType.CurrentValue == CellModel.CellType.Wall)
                    {
                        _wallSpawner.Create(new Vector3(x, y, 0));
                    }
                    else if (_map._cells[x, y].cellType.CurrentValue == CellModel.CellType.Point)
                    {
                        _ballSpawner.Create(new Vector3(x, y, 0));
                    }
                }
            }
        }

        public async UniTaskVoid Update()
        {
        }

        public async UniTaskVoid FixedUpdate()
        {
        }

        public async UniTaskVoid LateUpdate()
        {
        }

        public async UniTask Exit()
        {
        }
    }
}