using R3;
using UnityEngine;

namespace _Assets.Scripts.Services.Models
{
    public class PacmanMoveModel
    {
        public ReactiveProperty<Vector3> CurrentPosition = new();
        public ReactiveProperty<Vector3> TargetPosition = new();
    }
}