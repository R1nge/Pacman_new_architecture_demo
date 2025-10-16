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
    }
}