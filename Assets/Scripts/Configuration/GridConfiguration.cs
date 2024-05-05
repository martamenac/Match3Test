using UnityEngine;
namespace MMA.Configuration
{
    [CreateAssetMenu(menuName = MMA.Utils.EditorUtils.ConfigMenuDirection + "Grid configuration")]
    public class GridConfiguration : ScriptableObject
    {
        public int NumberOfRows = 10;
        public int NumberOfColumns = 10;

        public int AmountOfTileTypes = 1;
    }
}