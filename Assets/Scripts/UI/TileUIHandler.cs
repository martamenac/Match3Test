using MMA.Core;
using TMPro;
using UnityEngine;

namespace MMA.UI
{
    public class TileUIHandler : MonoBehaviour
    {
        public GridTile Tile;

        [Header("Testing")]
        [SerializeField] private TextMeshProUGUI _text;

        public void Initialize(GridTile tile)
        {
            Tile = tile;

            if (_text != null)
                _text.text = tile.TileType.ToString();
        }
    }
}