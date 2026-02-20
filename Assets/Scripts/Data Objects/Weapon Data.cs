using UnityEngine;

namespace DUNGEON.Data
{
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "DUNGEON/Items/Weapon")]
    public class WeaponSO : ItemSO
    {
        [Header("Combat Stats")]
        public DamageType damageType;

        [Header("Damage Formula (e.g. 1d8 + 0)")]
        [Tooltip("Number of dice to roll (The '1' in 1d8).")]
        public int diceCount = 1;
        [Tooltip("Sides on the die (The '8' in 1d8).")]
        public int diceSides = 8;
        [Tooltip("Magical bonus (e.g. +1 Sword). Adds to Attack AND Damage.")]
        public int magicBonus = 0;

        [Header("Scaling & Properties")]
        [Tooltip("Primary stat for Attack/Damage rolls (usually Strength).")]
        public StatAttribute scalingStat = StatAttribute.Strength;

        [Tooltip("If TRUE, uses Dexterity if it's higher than Strength.")]
        public bool isFinesse;
        [Tooltip("If TRUE, can be used in off-hand.")]
        public bool isLight;
        [Tooltip("If TRUE, requires both hands (cannot use Shield).")]
        public bool isTwoHanded;

        public int range = 1; // 1 = Melee, >1 = Ranged/Reach

        private void Reset()
        {
            itemType = ItemType.Weapon;
            isStackable = false;
        }
    }
}