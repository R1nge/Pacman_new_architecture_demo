using UnityEngine;

namespace _Assets.Scripts.Configs
{
    public class ConfigProvider : MonoBehaviour
    {
        [SerializeField] private UIConfig uiConfig;
        public UIConfig UIConfig => uiConfig;
        [SerializeField] private GameConfig gameConfig;
        public GameConfig GameConfig => gameConfig;
    }
}