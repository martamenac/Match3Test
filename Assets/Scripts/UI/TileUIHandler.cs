using MMA.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MMA.UI
{
    public class TileUIHandler : MonoBehaviour
    {
        public GridTile Tile;

        public Image HighlitedBackground;

        [Header("Testing")]
        [SerializeField] private TextMeshProUGUI _text;

        public void Initialize(GridTile tile)
        {
            Tile = tile;

            if (_text != null)
                _text.text = tile.TileType.ToString();

            if (Tile.IsPartOfCombo)
                Highlight();
            else
                Tile.OnBecomePartOfCombo += Highlight;
        }

        private void OnDestroy()
        {
            Tile.OnBecomePartOfCombo -= Highlight;
        }

        private void Highlight()
        {
            HighlitedBackground.gameObject.SetActive(true);
        }
    }
}