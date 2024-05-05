using MMA.Core;
using TMPro;
using UnityEngine;

namespace MMA.UI
{
    public class TileUIHandler : MonoBehaviour
    {
        public Tile Tile;

        [Header("Testing")]
        [SerializeField] private TextMeshProUGUI _text;

        public void Initialize(Tile tile)
        {
            Tile = tile;

            if (_text != null)
                _text.text = tile.TileType.ToString();
        }
    }
}