using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Environment.Tile.ScriptTiles
{
    public class MonoEqualTile : MonoTile
    {
        private bool isActive;

        private void Awake()
        {
            //add the movable property to this tile
            Properties.AddProperties(TileProperty.Movable);
        }

        private void Update()
        {
            TryWriteProperty(Vector2Int.up);
            TryWriteProperty(Vector2Int.left);
        }

        private bool TryWriteProperty(Vector2Int _rTypePos)
        {
            if (CheckPositions(_rTypePos) == false)
                return false;

            //assignment logic

            return true;
        }

        private bool CheckPositions(Vector2Int _rTypePos)
        {
            return CheckPosition<MonoTile>(_rTypePos) && CheckPosition<MonoTile>(_rTypePos * -1);
        }

        private bool CheckPosition<T>(Vector2Int _rPos)
        {
            List<MonoTile> tileStack = level.GetTileStack(_rPos + Position); //gets the tile stack at the position
            return tileStack.OfType<T>().Any(); //filters the list for types and checks if there are any items in the list
        }
    }
}
