namespace _Assets.Scripts.Services.StateMachine.StatesCreators
{
    public class MainSceneStateCreator : IStateCreator
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly MainMenuStatesFactory _mainMenuStatesFactory;

        private MainSceneStateCreator(GameStateMachine gameStateMachine, MainMenuStatesFactory mainMenuStatesFactory)
        {
            _gameStateMachine = gameStateMachine;
            _mainMenuStatesFactory = mainMenuStatesFactory;
        }
        
        public void Init()
        {
            _gameStateMachine.AddState(GameStateType.Init, _mainMenuStatesFactory.CreateAsyncState(GameStateType.Init, _gameStateMachine));
            _gameStateMachine.AddState(GameStateType.Game, _mainMenuStatesFactory.CreateAsyncState(GameStateType.Game, _gameStateMachine));
        }

        public void Dispose()
        {
           _gameStateMachine.RemoveState(GameStateType.Init);
           _gameStateMachine.RemoveState(GameStateType.Game);
        }
    }
}