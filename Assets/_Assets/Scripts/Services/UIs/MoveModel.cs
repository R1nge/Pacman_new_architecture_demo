using R3;
using UnityEngine;

namespace _Assets.Scripts.Services.UIs
{
    public class MoveModel
    {
        public ReactiveProperty<Vector3> Position = new();
    }
}