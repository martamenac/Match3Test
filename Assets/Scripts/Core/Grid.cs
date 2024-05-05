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

                    Tiles[i, j] = tile;
                }
            }
        }

        public void SetNeighbours(GridTile tile, int row, int column)
        {
            tile.SetNeighbour(Direction.North, row <= 0 ? null : Tiles[row - 1, column]);
            tile.Neighbours[Direction.North]?.SetNeighbour(Direction.South, tile);

            tile.SetNeighbour(Direction.South, row >= NumberOfRows - 1 ? null : Tiles[row + 1, column]);
            tile.Neighbours[Direction.South]?.SetNeighbour(Direction.North, tile);

            tile.SetNeighbour(Direction.West, column <= 0 ? null : Tiles[row, column - 1]);
            tile.Neighbours[Direction.West]?.SetNeighbour(Direction.East, tile);

            tile.SetNeighbour(Direction.East, column >= NumberOfColumns - 1 ? null : Tiles[row, column + 1]);
            tile.Neighbours[Direction.East]?.SetNeighbour(Direction.West, tile);
        }

        private GridTile GetRandomTile(int amountOfTileTypes)
        {
            var tileType = UnityEngine.Random.Range(0, amountOfTileTypes);

            return new GridTile(tileType);
        }
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