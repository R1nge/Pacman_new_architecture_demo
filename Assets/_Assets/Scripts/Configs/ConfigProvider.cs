using UnityEngine;

namespace _Assets.Scripts.Configs
{
    public class ConfigProvider : MonoBehaviour
    {
        [SerializeField] private UIConfig uiConfig;
        public UIConfig UIConfig => uiConfig;

        //TODO: create map config
        [SerializeField] private GameObject wall;
        public GameObject Wall => wall;
        [SerializeField] private GameObject point;
        public GameObject Point => point;
        [SerializeField] private int width = 28, height = 27;

        public int Width => width;

        public int Height => height;
    }
}