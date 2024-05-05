using System;
using System.Collections.Generic;

namespace MMA.Core
{
    public enum Direction { North, South, East, West }

    public class GridTile : Tile
    {
        public Dictionary<Direction, GridTile> Neighbours;

        public GridTile(int type) : base(type)
        {
            Neighbours = new Dictionary<Direction, GridTile>();
        }

        public void SetNeighbour(Direction direction, GridTile neighbourTile)
        {
            if (Neighbours.ContainsKey(direction))
                Neighbours[direction] = neighbourTile;
            else
                Neighbours.Add(direction, neighbourTile);
        }
    }
}