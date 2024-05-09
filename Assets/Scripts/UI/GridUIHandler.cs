using System;
using MMA.Configuration;
using MMA.Core;
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
                    _tileFactory.CreateTile(grid.Tiles[i,j], this, _tilesLayout.transform);
                }
            }
        }

        public void SwapTile(TileUIHandler tile, Core.Direction direction)
        {
            if (tile.Tile.HasNeighbour(direction, out var neighbour))
            {
                var neighbourTileHandler = GetTileHandler(neighbour.GridPosition);
                var firstTileIndex = tile.transform.GetSiblingIndex();

                Grid.SwapTiles(tile.Tile, neighbour);

                tile.transform.SetSiblingIndex(neighbourTileHandler.transform.GetSiblingIndex());
                neighbourTileHandler.transform.SetSiblingIndex(firstTileIndex);
            }
        }

        private TileUIHandler GetTileHandler(Vector2Int position)
        {
            return _tilesLayout.transform.GetChild(position.x * Grid.NumberOfColumns + position.y).GetComponent<TileUIHandler>();
        }
    }
}