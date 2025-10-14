using Cysharp.Threading.Tasks;

namespace _Assets.Scripts.Services
{
    public interface IAsyncState
    {
         UniTask Enter();
         UniTaskVoid Update();
         UniTaskVoid FixedUpdate();
         UniTaskVoid LateUpdate();
         UniTask Exit();
    }
}