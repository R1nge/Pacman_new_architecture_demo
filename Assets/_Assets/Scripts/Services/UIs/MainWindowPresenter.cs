using System;
using R3;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.UIs
{
    public class MainWindowPresenter : WindowPresenter
    {
        [SerializeField] private MainWindowView view;
        private CompositeDisposable _compositeDisposable;
        [Inject] private MoveModel _moveModel;

        private void Awake()
        {
            _compositeDisposable = new CompositeDisposable();
            _moveModel.Position.Subscribe(UpdateUI).AddTo(_compositeDisposable);
        }

        private void UpdateUI(Vector3 position)
        {
            view.SetText(position.ToString());
        }

        private void OnDestroy()
        {
            _compositeDisposable?.Dispose();
        }
    }
}