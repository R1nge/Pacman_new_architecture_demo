using UnityEngine;

namespace _Assets.Scripts.Configs
{
    public class ConfigProvider : MonoBehaviour
    {
        [SerializeField] private UIConfig uiConfig;
        public UIConfig UIConfig => uiConfig;

        [SerializeField] private GameObject wall;
        public GameObject Wall => wall;
        [SerializeField] private GameObject point;
        public GameObject Point => point;
    }
}