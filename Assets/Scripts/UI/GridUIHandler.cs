using MMA.Configuration;
using UnityEngine;
using Grid = MMA.Core.Grid;

namespace MMA.UI
{
    public class GridUIHandler : MonoBehaviour
    {
        [SerializeField] private GridConfiguration _configuration;  //This would be somewhere else but for simplicity it's here
        [SerializeField] private TileFactory _tileFactory;

        [Header("References")]
        [SerializeField] private FlexibleGridLayout _tilesLayout;

        public Grid Grid;

        //This would also be called from somewhere else, but for simplicity it's here
        private void Start()
        {
            GenerateGrid(_configuration);
        }

        public void GenerateGrid(GridConfiguration config)
        {
            Grid = new Grid(config.NumberOfRows, config.NumberOfColumns);

            SpawnTiles(Grid, config.AmountOfTileTypes);
        }

        public void SpawnTiles(Grid grid, int amountOfTileTypes)
        {
            grid.Fill(amountOfTileTypes);
            _tilesLayout.fitType = FlexibleGridLayout.FitType.FIXEDROWS;
            _tilesLayout.rows = grid.NumberOfRows;

            for (int i = 0; i < grid.NumberOfRows; i++)
            {
                for (int j = 0; j < grid.NumberOfColumns; j++)
                {
                    _tileFactory.CreateTile(grid.Tiles[i,j], _tilesLayout.transform);
                }
            }
        }
    }
}