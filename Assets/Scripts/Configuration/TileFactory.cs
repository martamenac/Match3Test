using AYellowpaper.SerializedCollections;
using MMA.Core;
using UnityEngine;

namespace MMA.UI
{
    [CreateAssetMenu(menuName = MMA.Utils.EditorUtils.ConfigMenuDirection + "Tile factory")]
    public class TileFactory : ScriptableObject
    {
        public SerializedDictionary<int, TileUIHandler> Tiles;

        public TileUIHandler CreateTile(GridTile tile, GridUIHandler gridHandler, Transform parent = null)
        {
            var tileGO = Instantiate(Tiles[tile.TileType], parent);
            tileGO.Initialize(tile, gridHandler);

            return tileGO;
        }
    }
}