using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using MMA.Core;
using UnityEngine;

namespace MMA.UI
{
    [CreateAssetMenu(menuName = MMA.Utils.EditorUtils.ConfigMenuDirection + "Tile factory")]
    public class TileFactory : ScriptableObject
    {
        public SerializedDictionary<int, TileUIHandler> Tiles;

        public TileUIHandler CreateTile(Tile tile, Transform parent = null)
        {
            var tileGO = Instantiate(Tiles[tile.TileType], parent);
            tileGO.Initialize(tile);

            return tileGO;
        }
    }
}