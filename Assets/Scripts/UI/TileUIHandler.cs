using MMA.Core;
using UnityEngine;

namespace MMA.UI
{
    public class TileUIHandler : MonoBehaviour
    {
        public Tile Tile;

        public void Initialize(Tile tile)
        {
            Tile = tile;
        }
    }
}