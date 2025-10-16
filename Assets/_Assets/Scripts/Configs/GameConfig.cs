using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/Game config")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private GameObject wall;
        public GameObject Wall => wall;
        [SerializeField] private GameObject point;
        public GameObject Point => point;
        [SerializeField] private int width = 28, height = 27;

        public int Width => width;

        public int Height => height;
    }
}