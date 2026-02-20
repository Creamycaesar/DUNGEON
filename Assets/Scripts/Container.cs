using UnityEngine;
using DUNGEON.Data;

namespace DUNGEON.Gameplay
{
    public class Container : MonoBehaviour
    {
        [Header("Identity")]
        public string containerName = "Chest";

        [Header("Loot Settings")]
        [Tooltip("The Loot Table this container will roll from when opened.")]
        public LootTableSO lootTable;

        [Header("Visuals")]
        [Tooltip("Optional: The sprite to show when this container is empty/opened.")]
        public Sprite openSprite;

        [Header("State")]
        public bool isLocked;
        public bool isOpen;

        // We will add the "Open()" logic here later!
    }
}