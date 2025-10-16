using _Assets.Scripts.Services.Models;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services
{
    public class ScoreService
    {
        [Inject] private ScoreModel _scoreModel;

        public void Add(int amount)
        {
            _scoreModel.CurrentScore.Value += amount;
            
            if (_scoreModel.CurrentScore.CurrentValue > _scoreModel.HighScore.CurrentValue)
            {
                _scoreModel.HighScore.Value = _scoreModel.CurrentScore.CurrentValue;
            }

            Debug.Log($"Added score; current score: {_scoreModel.CurrentScore.CurrentValue}");
        }
    }
}