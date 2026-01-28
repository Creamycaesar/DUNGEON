using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

namespace DUNGEON.Data
{
    [CreateAssetMenu(fileName = "NewDungeonTheme", menuName = "DUNGEON/Environment/Dungeon Theme")]
    public class DungeonThemeSO : ScriptableObject
    {
        [Header("Visual Identity")]
        public string themeName;       // e.g., "Crypt", "Magma Core"
        public Color ambientColor = Color.white;

        [Header("Tile Assets")]
        [Tooltip("Primary floor tile. For variation, use a RandomTile/RuleTile here.")]
        public TileBase floorTile;

        [Tooltip("The rule tile for walls")]
        public TileBase wallTile;

        [Tooltip("Difficult Terrain: Rocks, Debris, Webs (Non-damaging)")]
        public List<TileBase> difficultTerrainTiles;

        [Tooltip("Liquid Hazards: Lava, Water, Acid")]
        public TileBase liquidTile;

        [Header("Navigation Props")]
        [Tooltip("The exit leading deeper (Stairs Down / Hole)")]
        public GameObject exitDownPrefab;
        [Tooltip("The exit leading back/out (Stairs Up / Ladder)")]
        public GameObject exitUpPrefab;
        public GameObject doorPrefab;

        [Header("Interactables")]
        [Tooltip("Containers: Chests, Barrels, Pots, Bookcases")]
        public List<GameObject> containerPrefabs;

        [Tooltip("Harvestables: Gem Rocks, Mushrooms, Veins")]
        public List<GameObject> resourceNodePrefabs;

        [Header("Decoration")]
        [Tooltip("Non-interactive props: Tables, Chairs, Statues")]
        public List<GameObject> decorationPrefabs;

        [Tooltip("Light Sources: Torches, Braziers (Animated)")]
        public List<GameObject> lightSourcePrefabs;

        [Header("Population")]
        public List<ItemSO> potentialLoot;

        [Tooltip("List of traps that can spawn in this biome (Spikes, Webs)")]
        public List<TrapSO> availableTraps;

        [Header("Generation Settings")]
        [Range(1, 10)] public int difficultyRating;
    }
}