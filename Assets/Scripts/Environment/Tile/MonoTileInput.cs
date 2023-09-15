using Game.Environment.Tile.Data;
using System;
using UnityEngine;

namespace Game.Environment.Tile
{
    public class MonoTileInput : MonoBehaviour
    {
        public static event Action OnInput;
        private static bool eventLock = false;

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

            if (eventLock == false) //if the event's InputEvent is locked
            {
                OnInput?.Invoke(); //invoke the InputEvent
                eventLock = true; //lock the input from calling the event
            }

            if ((horizontal || vertical) && lockInput == false)
            {
                MoveTile(new Vector2(horizontalAxis, verticalAxis));
                lockInput = true; //lock the input
            }
            else if ((horizontal || vertical) == false) //if both horizontal and vertical has no input
            {
                lockInput = false; //unlock input
                eventLock = false; //unlock the InputEvent
            }
        }

        /// <summary>
        /// moves the tile using the relative vector <paramref name="_direction"/>, first moves horizontally, then vertically
        /// </summary>
        private void MoveTile(Vector2 _direction)
        {
            //split vector into integers
            int x = Convert.ToInt32(_direction.x);
            int y = Convert.ToInt32(_direction.y);

            //make two new vectors for the different axes
            Vector2Int horizontal = new(x, 0);
            Vector2Int vertical = new(0, y);

            if (horizontal != Vector2Int.zero) //if the horizontal axis contains a value
                tile.Movement.Move(horizontal); //move the tile

            if (vertical != Vector2Int.zero) //if the vertical axis contains a value
                tile.Movement.Move(vertical); //move the tile
        }

        private bool CanReadInput()
        {
            bool canMove = true; //initially assume we can move
            canMove &= tile.Type.TileProperties.CheckProperties(TileProperty.Player); //check whether the tile is a player
            return canMove; //return results
        }
    }
}