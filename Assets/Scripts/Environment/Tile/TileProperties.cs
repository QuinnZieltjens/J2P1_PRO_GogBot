namespace Game.Environment.Tile
{
    public struct TileProperties
    {
        /// <summary>
        /// readonly, stores the raw integer value of the properties
        /// </summary>
        public TileProperty Properties { get; private set; }

        //constructor
        public TileProperties(TileProperty _properties = TileProperty.None)
        {
            Properties = _properties;
        }

        /// <summary>
        /// adds <paramref name="_filter"/> to the stored properties
        /// </summary>
        public void AddProperties(TileProperty _filter)
        {
            //uses an OR operator on all the bits within the enum using the filter
            Properties |= _filter;
        }

        /// <summary>
        /// removes <paramref name="_filter"/> from the stored properties
        /// </summary>
        public void RemoveProperties(TileProperty _filter)
        {
            //inverts the filter and removes it using an AND operator
            Properties &= ~_filter;
        }

        /// <summary>
        /// checks <see cref="properties"/> with <paramref name="_filter"/> to see whether it<br/>
        /// contains the properties within <paramref name="_filter"/>
        /// </summary>
        /// <returns>
        /// <see cref="bool"/> which is <see langword="true"/> whether <see cref="properties"/> matches with <paramref name="_filter"/>
        /// </returns>
        public readonly bool CheckProperties(TileProperty _filter)
        {
            //uses an AND operator on all the bits within the enum using the filter,
            //if it is equal to the integer value in '_filter' then it passes the filter
            return (Properties & _filter) == _filter;
        }
    }
}