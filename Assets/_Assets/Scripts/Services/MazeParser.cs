using System;
using System.Linq;
using _Assets.Scripts.Configs;
using _Assets.Scripts.Services.Models;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services
{
    public class MazeParser
    {
        [Inject] private ConfigProvider _configProvider;

        public CellModel[,] Parse()
        {
            var cells = new CellModel[_configProvider.GameConfig.Width, _configProvider.GameConfig.Height];
            for (var y = 0; y < cells.GetLength(1); y++)
            {
                for (var x = 0; x < cells.GetLength(0); x++)
                {
                    cells[x, y] = new CellModel(CellModel.CellType.None);
                }
            }

            var textFile = Resources.Load<TextAsset>("maze");
            var text = textFile.text;
            Debug.Log($"Total length of maze text: {text.Length}");
            var newlineCount = text.Count(c => c == '\n');
            Debug.Log($"Total newline characters in maze text: {newlineCount}");

            // Clean the text
            text = text.Replace("\r\n", "").TrimEnd(); // Normalize line endings and remove trailing whitespace
            text = text.Replace("\n", "").TrimEnd();
            Debug.Log($"Total length of maze text: {text.Length}");


            for (var i = 0; i < text.Length; i++)
            {
                var x = i % cells.GetLength(0);
                var y = i / cells.GetLength(0);

                var character = text[i];
                Debug.Log($"Maze x:{x} y:{y} char:{character}");
                if (character == '#')
                {
                    cells[x, y].cellType.Value = CellModel.CellType.Wall;
                    //Wall
                }
                else if (character == '.')
                {
                    cells[x, y].cellType.Value = CellModel.CellType.Point;
                    //Point/collectable
                }
                else if (character == '@')
                {
                    cells[x, y].cellType.Value = CellModel.CellType.None;
                    //Tunnel
                }
                else if (character == ' ')
                {
                    cells[x, y].cellType.Value = CellModel.CellType.None;
                    //Space
                }
                else
                {
                    cells[x, y].cellType.Value = CellModel.CellType.None;
                    Debug.LogWarning("Invalid character");
                }
            }

            return cells;
        }
    }
}