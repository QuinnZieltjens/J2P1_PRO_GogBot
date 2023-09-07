using UnityEngine;

namespace Game.Environment.Tile
{
    public class MonoTile : MonoBehaviour
    {
        [SerializeField] private Vector2Int position;
        [SerializeField] private TileProperty tileProperties;

        public TileMovement Movement { get; private set; }
        public TileProperties Properties { get; private set; }
        private MonoLevel level;

        private void Awake()
        {
            level = FindObjectOfType<MonoLevel>();
            Movement = new TileMovement(this, level, position);
            Properties = new TileProperties();
            Properties.AddProperties(tileProperties);
        }

        private void Update()
        {
            float x = Movement.Position.x;
            float y = Movement.Position.y;
            transform.position = new Vector3(x, y) + level.Origin;
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            //if the application is playing, early return
            if (Application.isPlaying == false)
                return;

            position = Movement.Position; //update the position in the editor
            tileProperties = Properties.GetValueRaw();
        }
#endif
    }
}