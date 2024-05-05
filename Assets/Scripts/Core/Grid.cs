using System;
using UnityEngine;

namespace MMA.Core
{
    public class Grid
    {
        public int NumberOfRows;
        public int NumberOfColumns;

        public Tile[,] Tiles;

        public Grid(int rows, int columns)
        {
            NumberOfRows = rows;
            NumberOfColumns = columns;

            Tiles = new Tile[NumberOfRows,NumberOfColumns];
        }

        public void Fill(int amountOfTileTypes)
        {
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    Tiles[i, j] = GetRandomTile(amountOfTileTypes);
                }
            }
        }

        private Tile GetRandomTile(int amountOfTileTypes)
        {
            var tileType = UnityEngine.Random.Range(0, amountOfTileTypes);
            return new Tile(tileType);
        }

        public void SwapTiles()
        {

        }

        public void ShiftColumnDown()
        {

        }

        public void SpawnNewTile()
        {

        }
    }
}