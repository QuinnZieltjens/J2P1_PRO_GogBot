using Game.Environment.Tile.Data;
using System;
using UnityEngine;

namespace Game.Environment.Tile
{
    public class MonoTileInput : MonoBehaviour
    {
        private MonoTile tile;
        private bool lockInput = false;

        private void Awake()
        {
            tile = GetComponent<MonoTile>();
        }

        private void Update()
        {
            if (CanReadInput() == false)
                return;

            float horizontalAxis = Input.GetAxisRaw("Horizontal");
            float verticalAxis = Input.GetAxisRaw("Vertical");
            bool horizontal = horizontalAxis != 0;
            bool vertical = verticalAxis != 0;
            Vector2Int moveRelative = Vector2Int.zero;

            if (horizontal)
                moveRelative.x = Convert.ToInt32(horizontalAxis);

            if (vertical)
                moveRelative.y = Convert.ToInt32(verticalAxis);

            if ((horizontal || vertical) && lockInput == false)
            {
                tile.Movement.Move(moveRelative);
                lockInput = true;
            }
            else if ((horizontal || vertical) == false)
            {
                lockInput = false;
            }
        }

        private bool CanReadInput()
        {
            bool canMove = true; //initially assume we can move
            canMove &= tile.Type.TileProperties.CheckProperties(TileProperty.Player); //check whether the tile is a player
            return canMove; //return results
        }
    }
}