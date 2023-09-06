using System;
using System.Collections.Generic;
using UnityEngine;
using Game.Environment.Tiles;

namespace Game.Environment
{
    internal class Level
    {
        /// <summary>
        /// sets the level size as a <see cref="Vector2Int"/>, x and y cannot be a value lower than 0
        /// </summary>
        public Vector2Int LevelSize
        {
            get => levelSize; //just return levelSize on get
            set
            {
                //throw an exception if the given size is less than 0
                if (Util.IsMin(value.x, 0) || Util.IsMin(value.y, 0))
                    throw new ArgumentException("level size cannot be set to a number lower than 0\n" +
                        $"Attempted to set set level size to: {value}");
                //set the level size to the value
                levelSize = value;
            }
        }

        private Vector2Int levelSize;   //the set level size as an integer 2D array
        private List<Tile>[,] objects;   //2D array of integer lists (readonly)


        public Level()
        {
            InitArray();
        }

        /// <summary>
        /// builds the level in unity
        /// </summary>
        private void InitArray()
        {
            //define the 2D array
            objects = new List<Tile>[levelSize.x, levelSize.y];

            //loop through the X axis
            for (int x = 0; x < levelSize.x; x++)
            {
                //loop through the Y axis
                for (int y = 0; y < levelSize.y; y++)
                {
                    //define the list at position (x, y) in the 2D array
                    objects[x, y] = new List<Tile>();
                }
            }
        }

        /// <summary>
        /// builds the level in unity
        /// </summary>
        public void Build()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// checks whether <paramref name="_position"/> is a valid position
        /// </summary>
        public bool IsValidPosition(Vector2Int _position)
        {
            //if either x or y is out of bounds, return false
            bool isValid = false; //not really necessary assignment, but is here for readability
            isValid |= Util.IsRange(_position.x, 0, levelSize.x) == false; //checks whether the X axis is isn't range
            isValid |= Util.IsRange(_position.y, 0, levelSize.y) == false; //checks whether the Y axis is isn't range
            return isValid; //invert the results due to it currently being true when the value is out of range.
        }

        /// <summary>
        /// gives all objects at a given position,<br/>
        /// generates <see cref="ArgumentOutOfRangeException"/> if the position is an invalid one.
        /// </summary>
        /// <param name="_position"></param>
        /// <returns>the list of the objects located at <paramref name="_position"/></returns>
        public List<Tile> GetObjectsAt(Vector2Int _position)
        {
            //parse the position to 2 integers & check the integers if they are within the range
            int x = Util.Range(_position.x, 0, levelSize.x);
            int y = Util.Range(_position.y, 0, levelSize.y);

            //return the list
            return objects[x, y];
        }
    }
}
