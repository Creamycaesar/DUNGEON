using UnityEngine;

namespace DUNGEON.Data
{
    [CreateAssetMenu(fileName = "NewConsumable", menuName = "DUNGEON/Items/Consumable")]
    public class ConsumableSO : ItemSO
    {
        [Header("Consumable Effects")]
        public EffectType useEffect;

        [Tooltip("Used for BuffStat (Which stat?) or Resistance/Breath (Which element?).")]
        public StatAttribute targetStat;
        [Tooltip("Used for GrantResistance or ConeBreath.")]
        public DamageType effectElement;

        [Header("Dice Formula / Magnitude")]
        [Tooltip("For Healing, Damage, or Stat Buff amount.")]
        public int diceCount = 0;
        public int diceSides = 0;
        public int flatBonus = 0;

        [Header("Status Logic")]
        public int durationTurns;      // 0 = Instant

        [Header("Survival")]
        public bool isFood;
        public int nutritionValue;

        private void Reset()
        {
            itemType = ItemType.Consumable;
            isStackable = true;
            maxStackSize = 5;
        }
    }
}