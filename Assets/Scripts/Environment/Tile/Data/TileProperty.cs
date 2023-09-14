using System;

namespace Game.Environment.Tile.Data
{
    [Flags]
    public enum TileProperty : int
    {
        System = int.MinValue,  //signed bit
        All = -1,               //all bits
        None = 0,               //no bits
        Player = 1,
        Collides = 2,
        Movable = 4,
    }
}