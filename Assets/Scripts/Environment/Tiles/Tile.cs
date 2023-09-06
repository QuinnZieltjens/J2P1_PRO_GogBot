using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Environment.Tiles
{
    internal partial class Tile
    {
        private List<Vector2Int> positions = new();
        private TileProperty properties;
        private Level level;

        /// <summary>
        /// checks <see cref="properties"/> with <paramref name="_filter"/> to see whether it<br/>
        /// contains the properties within <paramref name="_filter"/>
        /// </summary>
        /// <returns>
        /// <see cref="bool"/> which is <see langword="true"/> whether <see cref="properties"/> matches with <paramref name="_filter"/>
        /// </returns>
        public bool CheckProperties(TileProperty _filter)
        {
            //uses an AND operator on all the bits within the enum,
            //if it is equal to the integer value in '_filter' then it passes the filter
            return (properties & _filter) == _filter;
        }

        /// <returns>
        /// the position which matches <paramref name="_position"/>
        /// </returns>
        private Vector2Int? GetPosition(Vector2Int _position)
        {
            //uses a predicate to find the fist item where the _position matches the item
            return positions.First(_item => _item == _position);
        }
    }
}