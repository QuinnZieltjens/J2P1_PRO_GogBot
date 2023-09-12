using UnityEngine;

namespace Game.Environment.Tile.ScriptTiles
{
    public class MonoPropertyTile //: MonoTile
    {
        [SerializeField] private TileProperty writeProperties; //the properties written to the type with equal

        public TileProperties Properties { get; private set; }

        //called once the script is being loaded
        private void Awake()
        {
            Properties = new TileProperties(writeProperties);
        }
    }
}