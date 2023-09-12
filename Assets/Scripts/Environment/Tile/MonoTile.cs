using System;
using UnityEngine;

namespace Game.Environment.Tile
{
    public abstract class MonoTile : MonoBehaviour
    {
        [SerializeField] private Vector2Int position;
        [SerializeField] private TileProperty tileProperties;

        public Vector2Int Position
        {
            get => position;
            set => position = level.IsValidPosition(value) ? value : throw new ArgumentOutOfRangeException();
        }

        public TileMovement Movement { get; private set; }
        public TileProperties Properties { get; private set; }

        protected MonoLevel level; //stores the level

        //called when the object is loaded
        private void Awake()
        {
            level = FindObjectOfType<MonoLevel>(); //find the level object
        }

        //called before the first frame
        private void Start()
        {
            Movement = new TileMovement(this, level); //initialize tile movement class
            Properties = new TileProperties();
            Properties.AddProperties(tileProperties);
        }

        //called upon every frame
        private void Update()
        {
            //set the correct unity position
            float x = Position.x; //implicit cast: X from int to float
            float y = Position.y; //implicit cast: Y from int to float
            transform.position = new Vector3(x, y) + level.Origin; //set the object's unity position, correct for the level origin
        }
    }
}