using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.VisualScripting;

namespace Game.Environment.Tile
{
    public class TileMovement
    {
        public Vector2Int Position { get; private set; }
        private readonly MonoLevel level;
        private readonly MonoTile tile;


        public TileMovement(MonoTile _tile, MonoLevel _level, Vector2Int _position)
        {
            tile = _tile;
            level = _level;
            Position = _position;

            //add this tile to the tileStack at the right position if it is not in that position
            List<MonoTile> tileStack = level.GetTileStack(Position);
            if (tileStack.Contains(_tile) == false)
                tileStack.Add(_tile);
        }

        /// <summary>
        /// moves the tile 
        /// </summary>
        /// <param name="_currentPos"></param>
        /// <param name="_relativePos"></param>
        /// <exception cref="NullReferenceException"></exception>
        public void Move(Vector2Int _relativePos)
        {
            Vector2Int newPos;

            //if the tile can't move, early return
            if (CanMove(_relativePos) == false)
                return;

            //calculate the new position
            newPos = Position + _relativePos;

            //loop through the tiles which are located at the moved to positions
            foreach (MonoTile moveToTile in level.GetTileStack(newPos).ToArray()) //uses .ToArray() to duplicate the collection so it's not modified whilst looping
                moveToTile.Movement.Move(_relativePos); //move the tile with the same relative position as this tile

            //update the level
            level.GetTileStack(Position).Remove(tile); //remove the current position from the tile stack
            level.GetTileStack(newPos).Add(tile); //add the tile at the new position to the tile stack

            //update the internal position
            Position = newPos;
        }

        /// <summary>
        /// checks whether the tile can move <paramref name="_relativePos"/>
        /// </summary>
        /// <param name="_currentPos">the current position of the tile</param>
        /// <param name="_relativePos">the relative position from the current position which the tile is moving to</param>
        private bool CanMove(Vector2Int _relativePos)
        {
            bool canMove; //whether the current tile can move to the position
            List<MonoTile> movedToTiles; //the tiles located at the position trying to move to
            Vector2Int newPos = Position + _relativePos; //calculate the new position

            //checks whether the position is a valid one
            if (level.IsValidPosition(newPos) == false)
                return false;

            movedToTiles = level.GetTileStack(newPos); //gets the tiles at the new position
            canMove = true; //initially assumes the tile can move

            //loops through all the tiles at the new position (skips this step if there are none)
            foreach (MonoTile movedToTile in movedToTiles)
            {
                //if the tile is movable, set canMove to that tile moving's result.
                if (movedToTile.Properties.CheckProperties(TileProperty.Movable))
                {
                    canMove &= movedToTile.Movement.CanMove(_relativePos); //if any tile can't move, canMove = false
                    continue; //continue the loop
                }

                //checks whether the tile collides.
                if (movedToTile.Properties.CheckProperties(TileProperty.Collides))
                    return false; //return false; tile can't move no matter what
            }

            //return the results
            return canMove;
        }
    }
}