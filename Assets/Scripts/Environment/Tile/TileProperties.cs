using Unity.VisualScripting;

namespace Game.Environment.Tile
{
    public class TileProperties
    {
        private TileProperty properties;

        public void AddProperties(TileProperty _filter)
        {
            //uses an OR operator on all the bits within the enum using the filter
            properties |= _filter;
        }

        public void RemoveProperties(TileProperty _filter)
        {
            //inverts the filter through using an AND operator
            properties &= ~_filter;
        }

        /// <summary>
        /// checks <see cref="properties"/> with <paramref name="_filter"/> to see whether it<br/>
        /// contains the properties within <paramref name="_filter"/>
        /// </summary>
        /// <returns>
        /// <see cref="bool"/> which is <see langword="true"/> whether <see cref="properties"/> matches with <paramref name="_filter"/>
        /// </returns>
        public bool CheckProperties(TileProperty _filter)
        {
            //uses an AND operator on all the bits within the enum using the filter,
            //if it is equal to the integer value in '_filter' then it passes the filter
            return (properties & _filter) == _filter;
        }

        public TileProperty GetValueRaw()
        {
            //returns the raw value of properties
            return properties;
        }
    }
}