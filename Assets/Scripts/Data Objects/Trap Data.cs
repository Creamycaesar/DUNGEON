using UnityEngine;

namespace DUNGEON.Data
{
    [CreateAssetMenu(fileName = "NewTrap", menuName = "DUNGEON/Environment/Trap")]
    public class TrapSO : ScriptableObject
    {
        [Header("Visuals")]
        public string trapName;
        public GameObject trapPrefab;
        [Tooltip("If TRUE, uses the floor tile beneath it. If FALSE, uses specific sprites.")]
        public bool useFloorAsDisguise = true;
        public Sprite specificHiddenSprite;
        public Sprite revealedSprite;
        public RuntimeAnimatorController trapAnimator;

        [Header("Detection")]
        public bool isHiddenByDefault = true;
        [Tooltip("Perception/Int score needed to spot this trap passively.")]
        public int detectionDifficulty = 10;

        [Header("Saving Throw (Avoidance)")]
        [Tooltip("Attribute used to dodge the initial trigger (e.g., Dexterity).")]
        public StatAttribute saveAttribute = StatAttribute.Dexterity;
        [Tooltip("The Difficulty Class (DC) to avoid the trap. Roll + Stat >= DC.")]
        public int saveDC = 12;
        [Tooltip("Does a successful save negate ALL damage? (True = Evasion, False = Half Damage)")]
        public bool successfulSaveNegatesDamage = false;

        [Header("Damage & Effects")]
        public DamageType damageType;
        public int minDamage;
        public int maxDamage;

        [Header("Status Effect (Trapped/Poisoned)")]
        public EffectType statusEffect;
        public int statusDuration; // 0 = Infinite until escaped

        [Header("Escape Mechanic")]
        [Tooltip("If the Status Effect is Restrained/Grappled, this is the DC to break out.")]
        public int escapeDC = 0;
        [Tooltip("Skill used to escape (e.g., Athletics for Pits).")]
        public Skill escapeSkill = Skill.Athletics;

        [Header("Trigger Logic")]
        public bool triggerOnStep = true;
        public bool isPeriodic;
        public int periodTurns;
    }
}