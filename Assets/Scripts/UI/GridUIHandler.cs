using MMA.Configuration;
using UnityEngine;
using Grid = MMA.Core.Grid;
namespace MMA.UI
{
    public class GridUIHandler : MonoBehaviour
    {
        //This would be somewhere else but for simplicity it's here
        [SerializeField] private GridConfiguration _configuration;

        public Grid Grid;

        //This would also be called from somewhere else, but for simplicity it's here
        private void Start()
        {
            GenerateGrid(_configuration);
        }

        public void GenerateGrid(GridConfiguration config)
        {
            Grid = new Grid(config.NumberOfRows, config.NumberOfColumns);

            SpawnTiles(Grid);
        }

        public void SpawnTiles(Grid grid)
        {
            grid.Fill();
        }
    }
}