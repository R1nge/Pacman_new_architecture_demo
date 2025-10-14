using System;
using _Assets.Scripts.Services.StateMachine.States;
using _Assets.Scripts.Services.UIs;

namespace _Assets.Scripts.Services.StateMachine
{
    public class MainMenuStatesFactory
    {
        private readonly WindowManager _windowManager;

        private MainMenuStatesFactory(WindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        public IAsyncState CreateAsyncState(GameStateType gameStateType, GameStateMachine gameStateMachine)
        {
            switch (gameStateType)
            {
                case GameStateType.Init:
                    return new InitState(gameStateMachine, _windowManager);
                case GameStateType.Game:
                    return new GameState(gameStateMachine);
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameStateType), gameStateType, null);
            }
        }
    }
}