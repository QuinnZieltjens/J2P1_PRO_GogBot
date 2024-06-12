using System;
using System.Collections.Generic;
using UnityEngine;
using Game.Environment.Tile;

namespace Game.Environment
{
    public class MonoLevel : MonoBehaviour
    {
        [SerializeField] private Vector2Int levelSize;  //the set level size as an 2D array (readonly)
        public Vector3 Origin { get; private set; }     //the point in unity which is (0, 0)
        private List<MonoTile>[,] objects;              //2D array of lists (readonly)

        //constructor, 
        private void Awake()
        {
            //check whether X and Y are not less than 0, throw an exception if they are
            if (levelSize.x < 0 || levelSize.y < 0) //if either X or Y are below 0
                throw new ArgumentException("level size cannot be set to a number lower than 0\n" +
                    $"Attempted to set set level size to: {levelSize}");

            //define the 2D array
            objects = new List<MonoTile>[levelSize.x, levelSize.y];

            //loop through the X axis
            for (int x = 0; x < levelSize.x; x++)
            {
                //loop through the Y axis
                for (int y = 0; y < levelSize.y; y++)
                {
                    //define the list at position (x, y) in the 2D array
                    objects[x, y] = new List<MonoTile>();
                }
            }

            //calculate the origin (where the (0, 0) point lies in unity)
            Vector3 origin = transform.position;
            origin.x -= levelSize.x / 2f;
            origin.y -= levelSize.y / 2f;
            Origin = origin;
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
        public List<MonoTile> GetTileStack(Vector2Int _position)
        {
            //parse the position to 2 integers & check the integers if they are within the range
            int x = Util.Range(_position.x, 0, levelSize.x);
            int y = Util.Range(_position.y, 0, levelSize.y);

            //return the list
            return objects[x, y];
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Vector3 cubeSize = new(levelSize.x, levelSize.y);
            Gizmos.DrawWireCube(transform.position, cubeSize);
        }
    }
}
