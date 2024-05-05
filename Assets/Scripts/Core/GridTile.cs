using System;
using System.Collections.Generic;

namespace MMA.Core
{
    public enum Direction { North, South, East, West }

    public class GridTile : Tile
    {
        public Dictionary<Direction, GridTile> Neighbours;
        public bool IsPartOfCombo = false;

        public Action OnBecomePartOfCombo;

        public GridTile(int type) : base(type)
        {
            Neighbours = new Dictionary<Direction, GridTile>();
        }

        public void SetNeighbour(Direction direction, GridTile neighbourTile)
        {
            if (neighbourTile == null)
                return;

            if (Neighbours.ContainsKey(direction))
                Neighbours[direction] = neighbourTile;
            else
                Neighbours.Add(direction, neighbourTile);

            IsPartOfCombo = IsPartOfCombo || CheckComboInDirection(direction);
            if (IsPartOfCombo)
                OnBecomePartOfCombo?.Invoke();
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