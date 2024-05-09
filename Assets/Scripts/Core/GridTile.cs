using System;
using System.Collections.Generic;
using UnityEngine;

namespace MMA.Core
{
    public enum Direction { North, South, East, West }

    public class GridTile : Tile
    {
        public Dictionary<Direction, GridTile> Neighbours;
        public bool IsPartOfCombo = false;

        public Action OnBecomePartOfCombo;

        private Vector2Int _gridPosition;

        public Vector2Int GridPosition
        {
            get => _gridPosition;
            set
            {
                _gridPosition = value;
            }
        }

        public GridTile(int type) : base(type)
        {
            Neighbours = new Dictionary<Direction, GridTile>();
        }

        public void SetNeighbour(Direction direction, GridTile neighbourTile)
        {
            if (neighbourTile == null)
                return;

            if (Neighbours.ContainsKey(direction))
            {
                if (Neighbours[direction] == neighbourTile)
                    return;

                Neighbours[direction] = neighbourTile;
            }
            else
                Neighbours.Add(direction, neighbourTile);

            IsPartOfCombo = IsPartOfCombo || CheckComboInDirection(direction);
        }

        public bool HasNeighbour(Direction direction, out GridTile neighbourTile)
        {
            neighbourTile = null;

            if (!Neighbours.ContainsKey(direction))
                return false;

            neighbourTile = Neighbours[direction];
            return true;
        }

        public bool CheckComboInDirection(Direction direction, int minConsecutiveTiles = 3)
        {
            GridTile tile = this;

            for (int i = 0; i < minConsecutiveTiles - 1; i++)
            {
                if (!tile.Matches(direction))
                    return false;

                tile = tile.Neighbours[direction];
            }

            return true;
        }

        public bool Matches(Direction direction)
        {
            if (!Neighbours.ContainsKey(direction))
                return false;

            return Neighbours[direction].Matches(this);
        }
    }
}