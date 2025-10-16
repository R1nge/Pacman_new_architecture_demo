using _Assets.Scripts.Services.Models;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services
{
    public class PacmanService
    {
        [Inject] private PacmanMoveModel _pacmanMoveModel;

        public Vector3 GetPacmanPosition()
        {
            return _pacmanMoveModel.CurrentPosition.CurrentValue;
        }

        public Vector3 GetPacmanTargetPosition()
        {
            return _pacmanMoveModel.TargetPosition.CurrentValue;
        }

        public void SetPacmanPosition(Vector3 position)
        {
            _pacmanMoveModel.CurrentPosition.Value = position;
        }

        public void SetPacmanTargetPosition(Vector3 positon)
        {
            _pacmanMoveModel.TargetPosition.Value = positon;
        }
    }
}