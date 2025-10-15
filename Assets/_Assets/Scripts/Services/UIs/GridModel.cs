namespace _Assets.Scripts.Services.UIs
{
    public class GridModel
    {
        public CellModel[,] _cells;

        public GridModel(int width, int height)
        {
            _cells = new CellModel[width, height];
        }
    }

    public class CellModel
    {
        public bool IsWall;
    }
}