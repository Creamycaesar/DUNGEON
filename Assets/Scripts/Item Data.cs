using UnityEngine;
using System.Collections.Generic;

namespace DUNGEON.Data
{
    // -------------------------------------------------------------------------
    // BASE ITEM (Generic items like Gold, Junk, or Keys)
    // -------------------------------------------------------------------------
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

    // -------------------------------------------------------------------------
    // WEAPONS
    // -------------------------------------------------------------------------
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "DUNGEON/Items/Weapon")]
    public class WeaponSO : ItemSO
    {
        [Header("Combat Stats")]
        public DamageType damageType;
        public int minDamage;
        public int maxDamage;
        public int range = 1; // 1 = Melee, >1 = Ranged

        [Tooltip("Chance (0-100) to critically strike")]
        public float critChance = 5f;

        private void Reset()
        {
            itemType = ItemType.Weapon;
            isStackable = false;
        }
    }

    // -------------------------------------------------------------------------
    // ARMOR
    // -------------------------------------------------------------------------
    [CreateAssetMenu(fileName = "NewArmor", menuName = "DUNGEON/Items/Armor")]
    public class ArmorSO : ItemSO
    {
        [Header("Defense Stats")]
        public EquipmentSlot equipSlot;
        public int defenseAmount;      // Reduces incoming damage
        public int agilityPenalty;     // Heavy armor might lower dodge chance

        private void Reset()
        {
            itemType = ItemType.Armor;
            isStackable = false;
        }
    }

    // -------------------------------------------------------------------------
    // CONSUMABLES (Potions, Food)
    // -------------------------------------------------------------------------
    [CreateAssetMenu(fileName = "NewConsumable", menuName = "DUNGEON/Items/Consumable")]
    public class ConsumableSO : ItemSO
    {
        [Header("Consumable Effects")]
        public EffectType useEffect;
        public int effectMagnitude;    // e.g., Heal 50 HP
        public int durationTurns;      // 0 for instant, >0 for status effect

        [Header("Survival")]
        public bool isFood;            // Does this satisfy hunger mechanics? (Caves of Qud style)
        public int nutritionValue;

        private void Reset()
        {
            itemType = ItemType.Consumable;
            isStackable = true;
            maxStackSize = 10;
        }
    }
}