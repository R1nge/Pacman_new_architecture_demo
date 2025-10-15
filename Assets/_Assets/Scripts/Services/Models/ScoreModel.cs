using R3;

namespace _Assets.Scripts.Services.Models
{
    public class ScoreModel
    {
        public ReactiveProperty<int> CurrentScore = new();
        public ReactiveProperty<int> HighScore = new();
    }
}