using UnityEngine;

namespace DUNGEON.Data
{
    // D&D 5e Core Attributes
    public enum StatAttribute
    {
        Strength,       // Athletics, Attack Rolls (Melee)
        Dexterity,      // Acrobatics, Stealth, Attack Rolls (Ranged/Finesse), AC
        Constitution,   // HP, Concentration
        Intelligence,   // Arcana, History, Investigation
        Wisdom,         // Perception, Medicine, Survival
        Charisma        // Persuasion, Intimidation
    }

    // D&D 5e Standard Skills
    public enum Skill
    {
        None,

        // Strength
        Athletics,

        // Dexterity
        Acrobatics,
        SleightOfHand,
        Stealth,

        // Intelligence
        Arcana,
        History,
        Investigation,
        Nature,
        Religion,

        // Wisdom
        AnimalHandling,
        Insight,
        Medicine,
        Perception,
        Survival,

        // Charisma
        Deception,
        Intimidation,
        Performance,
        Persuasion
    }

    // Defines the broad category of an item
    public enum ItemType
    {
        Resource,   // Gold, Crafting materials, Gems
        Weapon,     // Swords, Axes, Bows
        Armor,      // Chestplates, Helmets
        Consumable, // Potions, Food, Scrolls, Mushrooms
        Accessory,  // Rings & Necklaces
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

    // D&D 5e Standard Damage Types
    public enum DamageType
    {
        Slashing,    // Swords, Axes
        Piercing,    // Spears, Arrows, Spikes
        Bludgeoning, // Hammers, Falling rocks, Falls
        Acid,        // Corrosive
        Cold,        // Ice
        Fire,        // Flames
        Force,       // Pure magical energy
        Lightning,   // Electricity
        Necrotic,    // Wither, death energy
        Poison,      // Toxins
        Psychic,     // Mental damage
        Radiant,     // Holy light
        Thunder      // Sonic boom/shockwaves
    }

    // D&D 5e Conditions + Utility Effects
    public enum EffectType
    {
        None,

        // --- Instant Effects ---
        HealHP,
        RestoreMana,
        Teleport,

        // --- D&D 5e Conditions ---
        Blinded,        // Can't see, Disadvantage on attacks
        Charmed,        // Can't hurt charmer, charmer has advantage socially
        Deafened,       // Can't hear
        Exhaustion,     // 6 levels of debuffs ending in death
        Frightened,     // Disadvantage while source is visible, can't move closer
        Grappled,       // Speed 0
        Incapacitated,  // No actions or reactions
        Invisible,      // Advantage on attacks, Disadvantage to be hit
        Paralyzed,      // Incapacitated, auto-fail STR/DEX saves, attacks against are Crits
        Petrified,      // Stone, resistance to all damage
        Poisoned,       // Disadvantage on attacks and ability checks
        Prone,          // Lying down, crawl speed
        Restrained,     // Speed 0, Disadvantage on attacks, Advantage to be hit (Good for Webs/Pits)
        Stunned,        // Incapacitated, can't move, fail STR/DEX saves
        Unconscious,    // Asleep/Knocked out

        // --- Custom/Legacy ---
        Burning,        // DOT (Damage Over Time)
        Bleeding,       // DOT (Damage Over Time)
        Confused,        // Random actions
        // --- Actions/Attacks ---
        ConeBreath,     // Potion of Fire Breath

        // --- Buffs ---
        BuffStat,       // Hill Giant Strength (Set Stat)
        BuffDamage,     // Potion of Pugilism (+Damage on hit)
        GrantResistance,// Potion of Resistance
        FreeAction,     // Immunity to Restrained/Paralyzed/Difficult Terrain
        WaterBreathing  // Water breathing
    }
}