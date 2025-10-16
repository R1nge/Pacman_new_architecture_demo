using _Assets.Scripts.Services.Models;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services
{
    public class MazeService
    {
        [Inject] private GridModel _map;

        public CellModel GetCell(int x, int y)
        {
            return _map._cells[x, y];
        }

        public void SetCellType(int x, int y, CellModel.CellType newCellType)
        {
            _map._cells[x, y].cellType.Value = newCellType;
        }

        public CellModel.CellType GetCellType(int x, int y)
        {
            return _map._cells[x, y].cellType.CurrentValue;
        }

        /// <summary>
        /// Warps player to the opposite or next portal
        /// </summary>
        /// <param name="position">Pacman position</param>
        /// <returns>Portal position or pacman position if failed</returns>
        public Vector3 TryWarp(Vector3 position)
        {
            for (int x = 0; x < _map._cells.GetLength(0); x++)
            {
                if (_map._cells[x, (int)position.y].cellType.CurrentValue == CellModel.CellType.Warp && x != (int)position.x)
                {
                    return new Vector3(x, position.y, 0);
                }
            }

            return position;
        }
    }
}