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

        public void InitializeMaze(CellModel[,] maze)
        {
            _width = maze.GetLength(0);
            _height = maze.GetLength(1);
            _cells = maze;
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
            Point = 2,
            Warp = 3
        }
    }
}