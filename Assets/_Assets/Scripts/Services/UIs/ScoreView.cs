using TMPro;
using UnityEngine;

namespace _Assets.Scripts.Services.UIs
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        public void UpdateScore(int score)
        {
            scoreText.text = $"Current score: {score}";
        }
    }
}