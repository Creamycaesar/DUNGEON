using UnityEngine;
using System.Collections.Generic;

namespace DUNGEON.Data
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "DUNGEON/Items/Generic Item")]
    public class ItemSO : ScriptableObject
    {
        [Header("Core Data")]
        public string itemName;
        [TextArea(3, 5)] public string description;
        public Sprite icon;
        public ItemType itemType;

        [Header("Visuals")]
        [Tooltip("If true, the UI/World object can play a shine/glow effect")]
        public bool hasShineAnimation;
        [Tooltip("Assign an Animator Controller for idle animations (e.g. spinning coin, glowing sword)")]
        public RuntimeAnimatorController animator;

        [Header("Economy & Stacking")]
        public int goldValue;          // How much merchants pay for it
        public bool isStackable;       // Can multiple occupy one grid slot?
        public int maxStackSize = 1;

        // Helper to validate logic (e.g., Gold is always stackable)
        protected virtual void OnValidate()
        {
            if (itemType == ItemType.Resource) isStackable = true;
        }
    }
}