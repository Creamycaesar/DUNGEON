using UnityEngine;

namespace DUNGEON.Data
{
    [CreateAssetMenu(fileName = "NewAccessory", menuName = "DUNGEON/Items/Accessory")]
    public class AccessorySO : ItemSO
    {
        [Header("Equipment Slot")]
        public EquipmentSlot equipSlot; // Usually Finger or Neck

        [Header("Defensive Bonuses")]
        [Tooltip("Adds to Armor Class (e.g., Ring of Protection +1).")]
        public int defenseBonus;

        [Header("Stat Buffs")]
        [Tooltip("Which attribute to buff (e.g. Constitution for Amulet of Health).")]
        public StatAttribute buffAttribute;
        [Tooltip("Amount to add to the stat (e.g. +2).")]
        public int buffAmount;

        [Header("Passive Effects")]
        [Tooltip("Constant effect while equipped (e.g. GrantResistance). If set to a Condition (like Restrained), it grants IMMUNITY to that condition.")]
        public EffectType passiveEffect;
        [Tooltip("Element for the resistance (e.g. Fire).")]
        public DamageType effectElement;

        [Header("Active Ability (Optional)")]
        [Tooltip("Effect when 'Used' from equipment bar (e.g. Ring of the Ram).")]
        public EffectType activeEffect;
        public DamageType activeDamageType;
        public int activeDiceCount;
        public int activeDiceSides;
        public int activeRange;
        public int activeCooldownTurns;

        private void Reset()
        {
            itemType = ItemType.Accessory;
            isStackable = false;
        }
    }
}