using System.Collections.Generic;
using UnityEngine;

namespace MMA.Core
{
    public class Grid
    {
        public int NumberOfRows;
        public int NumberOfColumns;

        public GridTile[,] Tiles;

        public Grid(int rows, int columns)
        {
            NumberOfRows = rows;
            NumberOfColumns = columns;

            Tiles = new GridTile[NumberOfRows,NumberOfColumns];
        }

        public void Fill(int amountOfTileTypes)
        {
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    var tile = GetRandomTile(amountOfTileTypes);
                    SetNeighbours(tile, i, j);
                    var exceptions = new List<int>();

                    while (tile.IsPartOfCombo || exceptions.Count >= amountOfTileTypes)
                    {
                        exceptions.Add(tile.TileType);
                        tile = GetRandomTile(amountOfTileTypes, exceptions);
                        SetNeighbours(tile, i, j);
                    }

                    Tiles[i, j] = tile;
                }
            }
        }

        public void SetNeighbours(GridTile tile, int row, int column)
        {
            //North
            tile.SetNeighbour(Direction.North, row <= 0 ? null : Tiles[row - 1, column]);
            if (tile.HasNeighbour(Direction.North, out var northNeighbour))
                northNeighbour.SetNeighbour(Direction.South, tile);

            //South
            tile.SetNeighbour(Direction.South, row >= NumberOfRows - 1 ? null : Tiles[row + 1, column]);
            if (tile.HasNeighbour(Direction.South, out var southNeighbour))
                southNeighbour.SetNeighbour(Direction.North, tile);

            //West
            tile.SetNeighbour(Direction.West, column <= 0 ? null : Tiles[row, column - 1]);
            if (tile.HasNeighbour(Direction.West, out var westNeighbour))
                westNeighbour.SetNeighbour(Direction.East, tile);

            //East
            tile.SetNeighbour(Direction.East, column >= NumberOfColumns - 1 ? null : Tiles[row, column + 1]);
            if (tile.HasNeighbour(Direction.East, out var eastNeighbour))
                eastNeighbour.SetNeighbour(Direction.West, tile);
        }

        private GridTile GetRandomTile(int amountOfTileTypes, List<int> exceptions = null)
        {
            if (exceptions == null)
                exceptions = new List<int>();

            int tileType;
            do  //This approach could cause an infinite loop or do many iterations before finding the right type
            {
                tileType = Random.Range(0, amountOfTileTypes);
            }
            while (exceptions.Contains(tileType));

            return new GridTile(tileType);
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