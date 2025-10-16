using System;
using _Assets.Scripts.Services.Models;
using R3;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.UIs
{
    public class ScorePresenter : WindowPresenter
    {
        [SerializeField] private ScoreView scoreView;
        [Inject] private ScoreModel _scoreModel;
        private CompositeDisposable _compositeDisposable;

        private void Awake()
        {
            _compositeDisposable = new CompositeDisposable();
            _scoreModel.CurrentScore.Subscribe(UpdateScore).AddTo(_compositeDisposable);
        }

        private void UpdateScore(int score)
        {
            scoreView.UpdateScore(score);
        }

        private void OnDestroy()
        {
           _compositeDisposable?.Dispose();
        }
    }
}