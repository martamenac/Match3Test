namespace MMA.Core
{
    public class Tile
    {
        public int TileType;    //This is an int for simplicity

        public Tile(int type)
        {
            TileType = type;
        }

        public bool Matches(Tile otherTile)
        {
            return TileType == otherTile.TileType;
        }
    }
}