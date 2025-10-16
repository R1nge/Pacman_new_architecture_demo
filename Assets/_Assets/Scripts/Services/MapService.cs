using _Assets.Scripts.Services.Models;
using VContainer;

namespace _Assets.Scripts.Services
{
    public class MapService
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
    }
}