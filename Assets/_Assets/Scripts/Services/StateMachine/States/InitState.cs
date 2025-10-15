using _Assets.Scripts.Services.UIs;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class InitState : IAsyncState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly WindowManager _windowManager;

        public InitState(GameStateMachine stateMachine, WindowManager windowManager)
        {
            _stateMachine = stateMachine;
            _windowManager = windowManager;
        }

        public async UniTask Enter()
        {
            await _windowManager.Open(WindowType.Loading);
            await UniTask.Delay(1000);
            await _stateMachine.SwitchState(GameStateType.Game);

        }

        public async UniTaskVoid Update()
        {
            //Debug.Log("Updates");
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