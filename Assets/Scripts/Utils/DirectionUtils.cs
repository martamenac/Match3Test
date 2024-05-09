using MMA.Core;
using UnityEngine;

namespace MMA.Utils
{
    public static class DirectionUtils
    {
        public static Direction GetDirectionFromVector(Vector2 direction)
        {
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                //Horizontal
                if (direction.x > 0)
                    return Direction.East;
                else
                    return Direction.West;
            }
            else
            {
                //Vertical
                if (direction.y > 0)
                    return Direction.North;
                else
                    return Direction.South;
            }
        }

        public static Direction GetOpposite(Direction direction)
        {
            return direction switch
            {
                Direction.North => Direction.South,
                Direction.South => Direction.North,
                Direction.East => Direction.West,
                Direction.West => Direction.East,
                _ => Direction.North,
            };
        }
    }
}