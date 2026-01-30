using UnityEngine;

namespace DUNGEON.Data
{
    [CreateAssetMenu(fileName = "NewTrap", menuName = "DUNGEON/Environment/Trap")]
    public class TrapSO : ScriptableObject
    {
        [Header("Visuals")]
        public string trapName;
        public GameObject trapPrefab;  // The prefab with the "Active/Spikes" sprite on it

        [Tooltip("If TRUE, the trap starts invisible (showing the Floor Tilemap underneath). If FALSE, it uses the specific sprite below.")]
        public bool useFloorAsDisguise = true;

        [Tooltip("Only needed if you want a specific 'fake' look (like a cracked stone) instead of invisible.")]
        public Sprite specificHiddenSprite;

        [Tooltip("Optional. Only needed if the Prefab doesn't already have the correct 'Sprung' sprite.")]
        public Sprite revealedSprite;

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
        public EffectType statusEffect;
        public int statusDuration;

        [Header("Trigger Logic")]
        [Tooltip("Does it trigger when stepped on?")]
        public bool triggerOnStep = true;

        [Tooltip("Does it trigger every X turns? (e.g. Spikes extending/retracting)")]
        public bool isPeriodic;
        public int periodTurns;
    }
}