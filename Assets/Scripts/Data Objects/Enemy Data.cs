using UnityEngine;

namespace DUNGEON.Data
{
    // A reusable block for stats, useful for both Players and Enemies
    [System.Serializable]
    public class StatBlock
    {
        public int strength;    // Melee Dmg
        public int agility;     // Dodge / Turn Order
        public int toughness;   // HP
        public int intelligence;// Skill usage
        public int willpower;   // Resistance
    }

    [CreateAssetMenu(fileName = "NewEnemy", menuName = "DUNGEON/Characters/Enemy")]
    public class EnemyDataSO : ScriptableObject
    {
        [Header("Identity")]
        public string enemyName;
        [TextArea] public string description;

        [Header("Visuals")]
        public Sprite idleSprite; // Fallback if no animator
        [Tooltip("Contains states for Idle, Move, Attack, Hit, Die")]
        public RuntimeAnimatorController animator;

        [Header("Stats")]
        public StatBlock baseStats;
        public int maxHP;
        public int baseExpReward;

        [Header("Combat Logic")]
        public DamageType attackElement;
        public int visionRange = 7;
        [Range(1, 10)] public int difficultyRating;

        // Future hook for loot
        // public LootTableSO dropTable;
    }
}