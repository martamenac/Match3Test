using MMA.Core;
using MMA.Utils;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MMA.UI
{
    [RequireComponent(typeof(Button))]
    public class TileUIHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public GridTile Tile;

        [Header("Testing")]
        public Image HighlitedBackground;
        [SerializeField] private TextMeshProUGUI _text;

        //I used [SerializeField] to force serialization and [HideInInspector] to make sure we cannot asign it manually.
        //This makes sure it's asigned and we don't have to use the GetComponent on Awake.
        [SerializeField][HideInInspector] private Button _button;

        private GridUIHandler _gridHandler;
        private Vector2 _initialPressPosition;

        private void Awake()
        {
            if (_button == null)
                _button = GetComponent<Button>();
        }

        private void Update()
        {
            if (Tile == null)
                return;

            SetHighlight(Tile.IsPartOfCombo);
        }

        public void Initialize(GridTile tile, GridUIHandler gridHandler)
        {
            Tile = tile;
            _gridHandler = gridHandler;

            if (_text != null)
                _text.text = tile.TileType.ToString();
        }

        private void SetHighlight(bool value)
        {
            HighlitedBackground.gameObject.SetActive(value);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _initialPressPosition = eventData.position;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            var swipeVector = eventData.position - _initialPressPosition;
            _gridHandler.SwapTile(this, DirectionUtils.GetDirectionFromVector(swipeVector));
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_button == null)
                _button = GetComponent<Button>();
        }
#endif
    }
}