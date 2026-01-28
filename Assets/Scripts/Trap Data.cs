using UnityEngine;

namespace DUNGEON.Data
{
    [CreateAssetMenu(fileName = "NewTrap", menuName = "DUNGEON/Environment/Trap")]
    public class TrapSO : ScriptableObject
    {
        [Header("Visuals")]
        public string trapName;
        public GameObject trapPrefab;  // The actual object spawned in the world
        public Sprite hiddenSprite;    // What it looks like before spotted
        public Sprite revealedSprite;  // What it looks like after spotting

        [Tooltip("Controller for Spikes extending, Gas venting, etc.")]
        public RuntimeAnimatorController trapAnimator;

        [Header("Mechanics")]
        public bool isHiddenByDefault = true;
        [Tooltip("Perception score needed to spot this trap")]
        public int detectionDifficulty = 5;

        [Header("Effects")]
        public DamageType damageType;
        public int minDamage;
        public int maxDamage;
        public EffectType statusEffect; // e.g., Poison the player
        public int statusDuration;

        [Header("Trigger Logic")]
        [Tooltip("Does it trigger when stepped on?")]
        public bool triggerOnStep = true;

        [Tooltip("Does it trigger every X turns? (e.g. Spikes extending/retracting)")]
        public bool isPeriodic;
        public int periodTurns;
    }
}