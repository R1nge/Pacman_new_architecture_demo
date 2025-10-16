using System;
using System.Collections.Generic;
using R3;
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
        }

        public void InitializeMaze(CellModel[,] maze)
        {
            _cells = maze;
            DisplayMaze();
        }

        private void DisplayMaze()
        {
            for (int y = 0; y < _height; y++)
            {
                string line = "";
                for (int x = 0; x < _width; x++)
                {
                    line += _cells[x, y].cellType.CurrentValue == CellModel.CellType.Wall ? "#" : " ";
                }

                Debug.Log(line);
            }
        }
    }

    public class CellModel
    {
        public ReactiveProperty<CellType> cellType { get; private set; } = new ReactiveProperty<CellType>();

        public CellModel(CellType cellType)
        {
            this.cellType = new(cellType);
        }
        
        public enum CellType : byte
        {
            None = 0,
            Wall = 1,
            Point = 2
        }
    }
}