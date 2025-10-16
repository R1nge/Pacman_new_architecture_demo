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
            if (x >= _map._cells.GetLength(0))
            {
                x = _map._cells.GetLength(0) - 1;
            }

            if (y >= _map._cells.GetLength(1))
            {
                y = _map._cells.GetLength(1) - 1;
            }

            return _map._cells[x, y].cellType.CurrentValue;
        }

        /// <summary>
        /// Warps entity to the opposite or next portal
        /// Supports only portals at the start and the end of the map
        /// </summary>
        /// <param name="position">Entity position</param>
        /// <returns>Portal position or current entity position if failed</returns>
        public (bool, Vector3) TryWarp(Vector3 position)
        {
            if (_map._cells[(int)position.x, (int)position.y].cellType.CurrentValue == CellModel.CellType.Warp)
            {
                for (int x = 0; x < _map._cells.GetLength(0); x++)
                {
                    if (_map._cells[x, (int)position.y].cellType.CurrentValue == CellModel.CellType.Warp &&
                        x != (int)position.x)
                    {
                        if (x == 0)
                        {
                            return (true, new Vector3(1, position.y, 0));
                        }

                        return (true, new Vector3(x - 1, position.y, 0));
                    }
                }
            }

            return (false, position);
        }
    }
}