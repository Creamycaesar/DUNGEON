using UnityEngine;

namespace DUNGEON.Data
{
    // Defines the broad category of an item
    public enum ItemType
    {
        Resource,   // Gold, Crafting materials, Gems
        Weapon,     // Swords, Axes, Bows
        Armor,      // Chestplates, Helmets
        Consumable, // Potions, Food, Scrolls, Mushrooms
        Key         // Quest items, Door keys
    }

    // Specific slots for equipment
    public enum EquipmentSlot
    {
        None,
        Head,
        Chest,
        Legs,
        MainHand,
        OffHand,
        Finger,
        Neck
    }

    // Types of damage for combat calculations
    public enum DamageType
    {
        Physical,
        Fire,
        Ice,
        Poison,
        Arcane,
        Holy
    }

    // For traps and consumables
    public enum EffectType
    {
        None,
        HealHP,
        RestoreMana,
        ApplyPoison,
        ApplyBurn,
        Stun,
        Teleport,
        Rooted,     // User added: For Webs
        Confused    // Good for mushrooms/hallucinations
    }
}