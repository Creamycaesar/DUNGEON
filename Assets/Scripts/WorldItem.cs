using UnityEngine;
using DUNGEON.Data;

namespace DUNGEON.Gameplay
{
    // Renamed from ItemPickup to WorldItem
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    // We add Animator support for "Shining" items
    [RequireComponent(typeof(Animator))]
    public class WorldItem : MonoBehaviour
    {
        [Header("Data")]
        public ItemSO itemData;

        [Header("Animation")]
        [Tooltip("Bobbing up and down animation speed.")]
        public float bobSpeed = 2f;
        public float bobHeight = 0.1f;

        private SpriteRenderer spriteRenderer;
        private Animator animator;
        private Vector3 startPos;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            startPos = transform.position;

            InitializeItem();
        }

        // Public so we can call it if we change the item at runtime (e.g. Chest drops loot)
        public void InitializeItem()
        {
            if (itemData == null) return;

            // 1. Set the Static Icon
            spriteRenderer.sprite = itemData.icon;

            // 2. Set the Animation (if it exists)
            if (itemData.animator != null)
            {
                animator.runtimeAnimatorController = itemData.animator;
                animator.enabled = true;
            }
            else
            {
                // Disable animator for static items so it doesn't override the sprite
                animator.enabled = false;
            }
        }

        private void Update()
        {
            // Simple visual bobbing effect
            // This works even with the Animator because the Animator changes the Sprite, 
            // while this changes the Transform position. They stack perfectly!
            float newY = startPos.y + (Mathf.Sin(Time.time * bobSpeed) * bobHeight);
            transform.position = new Vector3(startPos.x, newY, startPos.z);
        }
    }
}