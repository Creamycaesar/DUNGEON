using UnityEngine;

namespace DUNGEON.Data
{
    public enum PlacementLocation
    {
        Floor,      // Chests, Tables, Braziers, Floor Traps
        Wall,       // Torches, Sconces, Banners
        Any         // Things that can go anywhere (rare)
    }

    public class PlacementConfig : MonoBehaviour
    {
        [Header("Generation Rules")]
        [Tooltip("Where is this object allowed to spawn?")]
        public PlacementLocation validLocation = PlacementLocation.Floor;

        [Tooltip("If TRUE, this object allows other items to spawn on top of it (e.g., a Rug).")]
        public bool isWalkable = false;
    }
}