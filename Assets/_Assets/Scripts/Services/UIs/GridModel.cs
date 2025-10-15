using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Assets.Scripts.Services.UIs
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
                    _cells[x, y] = new CellModel(false);
                }

            }
            
            for (int x = 0; x < _width; x++)
            {
                _cells[x, 0] = new CellModel(true);
                _cells[x, _height - 1] = new CellModel(true);
            }

            for (int y = 0; y < _height; y++)
            {
                _cells[0, y] = new CellModel(true);
                _cells[_width - 1, y] = new CellModel(true);
            }

            //GenerateMazePaths();
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
                        _cells[x, y] = new CellModel(true); // Wall
                    else
                        _cells[x, y] = new CellModel(false); // Path
                }
            }

            //CreateSpecialPatterns();
        }

        private void CreateSpecialPatterns()
        {
            _cells[1, 3] = new CellModel(false);
            _cells[1, 4] = new CellModel(false);
            _cells[3, 1] = new CellModel(false);
        }

        private void DisplayMaze()
        {
            for (int y = 0; y < _height; y++)
            {
                string line = "";
                for (int x = 0; x < _width; x++)
                {
                    line += _cells[x, y].IsWall ? "#" : " ";
                }

                Debug.Log(line);
            }
        }
    }

    public class CellModel
    {
        public bool IsWall { get; private set; }

        public CellModel(bool isWall)
        {
            IsWall = isWall;
        }
    }
}