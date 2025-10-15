using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Assets.Scripts.Services.Models
{
    public class GridModel
    {
        public CellModel[,] _cells;
        public int _width, _height;

        public GridModel(int width, int height)
        {
            _width = width;
            _height = height;
            _cells = new CellModel[width, height];
            InitializeMaze();
        }

        private void InitializeMaze()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    _cells[x, y] = new CellModel(CellModel.CellType.Point);
                }

            }
            
            for (int x = 0; x < _width; x++)
            {
                _cells[x, 0] = new CellModel(CellModel.CellType.Wall);
                _cells[x, _height - 1] = new CellModel(CellModel.CellType.Wall);
            }

            for (int y = 0; y < _height; y++)
            {
                _cells[0, y] = new CellModel(CellModel.CellType.Wall);
                _cells[_width - 1, y] = new CellModel(CellModel.CellType.Wall);
            }

            GenerateMazePaths();
            DisplayMaze();
        }

        private void GenerateMazePaths()
        {
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>();

            for (int y = 1; y < _height - 1; y++)
            {
                for (int x = 1; x < _width - 1; x++)
                {
                    if ((x % 2 == 0) && (y % 2 == 0))
                        _cells[x, y] = new CellModel(CellModel.CellType.Wall); // Wall
                    else
                        _cells[x, y] = new CellModel(CellModel.CellType.Point); // Path
                }
            }
        }

        private void DisplayMaze()
        {
            for (int y = 0; y < _height; y++)
            {
                string line = "";
                for (int x = 0; x < _width; x++)
                {
                    line += _cells[x, y].cellType == CellModel.CellType.Wall ? "#" : " ";
                }

                Debug.Log(line);
            }
        }
    }

    public class CellModel
    {
        public CellType cellType { get; private set; }

        public CellModel(CellType cellType)
        {
            this.cellType = cellType;
        }
        
        public enum CellType : byte
        {
            None = 0,
            Wall = 1,
            Point = 2
        }
    }
}