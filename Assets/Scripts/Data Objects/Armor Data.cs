using UnityEngine;

namespace DUNGEON.Data
{
    public enum ArmorCategory
    {
        Light,  // AC + Full Dex Mod
        Medium, // AC + Dex Mod (Max 2)
        Heavy,  // AC only (No Dex)
        Shield  // +2 AC
    }

    [CreateAssetMenu(fileName = "NewArmor", menuName = "DUNGEON/Items/Armor")]
    public class ArmorSO : ItemSO
    {
        [Header("Defense Stats")]
        public EquipmentSlot equipSlot;

        [Tooltip("The Base Armor Class (e.g. Leather = 11, Chain Mail = 16).")]
        public int baseArmorClass;

        [Tooltip("Determines how Dexterity affects AC.")]
        public ArmorCategory armorCategory;

        [Header("Restrictions")]
        [Tooltip("Minimum Strength to wear without movement penalty.")]
        public int strengthRequirement;

        [Tooltip("If TRUE, Disadvantage on Stealth checks.")]
        public bool stealthDisadvantage;

        private void Reset()
        {
            itemType = ItemType.Armor;
            isStackable = false;

            // Defaults - Added null check to prevent creation crash
            if (!string.IsNullOrEmpty(itemName) && itemName.Contains("Shield"))
            {
                armorCategory = ArmorCategory.Shield;
            }
        }
    }
}