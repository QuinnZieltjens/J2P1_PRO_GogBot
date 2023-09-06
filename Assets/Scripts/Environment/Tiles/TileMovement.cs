using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Environment.Tiles
{
    internal partial class Tile
    {
        public void Move(Vector2Int _currentPos, Vector2Int _relativePos)
        {
            Vector2Int? movingPosition = GetPosition(_currentPos);
            Vector2Int newPos;

            //if there is no known position at the current position, throw a NullReferenceException
            if (movingPosition == null)
                throw new NullReferenceException($"Starting position nonexistent, {_currentPos}");

            //if the tile can't move, early return
            if (CanMove(_currentPos, _relativePos) == false)
                return;

            //calculate the new position
            newPos = _currentPos + _relativePos;

            //loop through the tiles which are located at the moved to positions
            foreach (Tile moveToTile in level.GetObjectsAt(newPos))
                moveToTile.Move(newPos, _relativePos); //move the tile with the same relative position as this tile

            //add the new position to the list
            positions.Add(newPos);
            positions.Remove((Vector2Int)movingPosition); //remove the current position from the list
        }

        /// <summary>
        /// checks whether the tile can move <paramref name="_relativePos"/>
        /// </summary>
        /// <param name="_currentPos">the current position of the tile</param>
        /// <param name="_relativePos">the relative position from the current position which the tile is moving to</param>
        private bool CanMove(Vector2Int _currentPos, Vector2Int _relativePos)
        {

            bool canMove; //whether the current tile can move to the position
            List<Tile> movedToTiles; //the tiles located at the position trying to move to
            Vector2Int newPos = _currentPos + _relativePos; //calculate the new position

            //checks whether the position is a valid one
            if (level.IsValidPosition(newPos) == false)
                return false;

            movedToTiles = level.GetObjectsAt(newPos); //gets the tiles at the new position
            canMove = true; //initially assumes the tile can move

            //loops through all the tiles at the new position (skips this step if there are none)
            foreach (Tile tile in movedToTiles)
            {
                //if the tile is movable, set canMove to that tile moving's result.
                if (tile.CheckProperties(TileProperty.Movable))
                {
                    canMove &= tile.CanMove(newPos, _relativePos); //if any tile can't move, canMove = false
                    continue; //continue the loop
                }

                //checks whether the tile collides.
                if (tile.CheckProperties(TileProperty.Collides))
                {
                    canMove = false; //set canMove to false
                    break; //don't bother to check more
                }
            }

            //return the results
            return canMove;
        }
    }
}