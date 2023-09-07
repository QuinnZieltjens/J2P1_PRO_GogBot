using UnityEngine;

namespace Game.Environment.Tiles
{
    public class MonoTile : MonoBehaviour
    {
        [SerializeField] private Vector2Int position;

        public TileMovement Movement { get; private set; }
        public TileProperties Properties { get; private set; }
        private Level level;

        private void Awake()
        {
            Movement = new TileMovement(this, level, position);
            Properties = new TileProperties();
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            //if the application is playing, update the position in the editor
            if (Application.isPlaying)
                position = Movement.Position;
        }
#endif
    }
}