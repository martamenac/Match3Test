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

        public void GenerateTiles()
        {
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    Tiles[i, j] = GetRandomTile();
                }
            }
        }

        private Tile GetRandomTile()
        {
            return new Tile(0);
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