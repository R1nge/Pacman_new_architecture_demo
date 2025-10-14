using VContainer.Unity;

namespace _Assets.Scripts.Services.StateMachine
{
    public class GameStateMachine : GenericAsyncStateMachine<GameStateType, IAsyncState>, ITickable, IFixedTickable, ILateTickable
    {
        public void Tick()
        {
           Update();
        }

        public void FixedTick()
        {
            FixedUpdate();
        }

        public void LateTick()
        {
            LateUpdate();
        }
    }
}