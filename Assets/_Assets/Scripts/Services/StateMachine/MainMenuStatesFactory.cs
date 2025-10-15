using System;
using _Assets.Scripts.Services.Models;
using _Assets.Scripts.Services.StateMachine.States;
using _Assets.Scripts.Services.UIs;

namespace _Assets.Scripts.Services.StateMachine
{
    public class MainMenuStatesFactory
    {
        private readonly WindowManager _windowManager;
        private readonly WallSpawner _wallSpawner;
        private readonly GridModel _map;
        private readonly BallSpawner _ballSpawner;

        private MainMenuStatesFactory(WindowManager windowManager, WallSpawner wallSpawner, GridModel map, BallSpawner ballSpawner)
        {
            _windowManager = windowManager;
            _wallSpawner = wallSpawner;
            _map = map;
            this._ballSpawner = ballSpawner;
        }

        public IAsyncState CreateAsyncState(GameStateType gameStateType, GameStateMachine gameStateMachine)
        {
            switch (gameStateType)
            {
                case GameStateType.Init:
                    return new InitState(gameStateMachine, _windowManager);
                case GameStateType.Game:
                    return new GameState(gameStateMachine, _wallSpawner, _map, _windowManager, _ballSpawner);
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameStateType), gameStateType, null);
            }
        }
    }
}