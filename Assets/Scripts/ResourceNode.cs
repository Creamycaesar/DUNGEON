using UnityEngine;
using DUNGEON.Data;

namespace DUNGEON.Gameplay
{
    public class ResourceNode : MonoBehaviour
    {
        [Header("Identity")]
        public string resourceName = "Crystal Formation";

        [Header("Durability")]
        [Tooltip("If FALSE, this object cannot be destroyed or harvested (e.g. permanent rocks).")]
        public bool isDestructible = true;

        [Tooltip("How much damage this object can take before breaking.")]
        public int hitPoints = 3;

        [Tooltip("Visual effect prefab to spawn when destroyed (dust/shards).")]
        public GameObject destroyEffect;

        [Header("Loot")]
        [Tooltip("The Loot Table used when this is destroyed or harvested.")]
        public LootTableSO lootTable;

        [Tooltip("If TRUE, attacking destroys the object but yields NO loot (requires Harvesting).")]
        public bool requireHarvestForLoot = false;

        [Header("Harvesting (Skill)")]
        [Tooltip("Skill required to harvest (e.g. Nature for Mushrooms). Set to None if only attackable.")]
        public Skill harvestSkill = Skill.None;
        public int harvestDC = 10;

        [Header("Movement Logic")]
        [Tooltip("Standard tile = 1. Difficult Terrain > 1.")]
        public int movementCost = 2; // Default to 'Difficult'

        // Called by Player Combat Script (Attacking)
        public void TakeDamage(int damage)
        {
            if (!isDestructible) return; // Ignore damage on Rocks

            hitPoints -= damage;
            // Optional: Play a "Tink" sound or wobble animation here

            if (hitPoints <= 0)
            {
                // If it REQUIRES harvesting, attacking it destroys it ("Ruined") without dropping loot
                bool shouldDrop = !requireHarvestForLoot;
                DestroyNode(shouldDrop);
            }
        }

        // Called by Player Interaction Script (Using Skill)
        public bool TryHarvest(int rollResult)
        {
            if (!isDestructible) return false; // Cannot harvest Rocks
            if (harvestSkill == Skill.None) return false;

            if (rollResult >= harvestDC)
            {
                Debug.Log($"Harvest Successful! Rolled {rollResult} vs DC {harvestDC}");
                DestroyNode(true); // Success = Drop Loot
                return true;
            }
            else
            {
                Debug.Log($"Harvest Failed. Rolled {rollResult} vs DC {harvestDC}");
                return false;
            }
        }

        private void DestroyNode(bool spawnLoot)
        {
            // 1. Spawn Loot (Only if allowed)
            if (spawnLoot && lootTable != null)
            {
                ItemSO drop = lootTable.GetRandomLoot();
                if (drop != null)
                {
                    Debug.Log($"{resourceName} yielded: {drop.itemName}");
                }
            }
            else if (!spawnLoot && lootTable != null)
            {
                Debug.Log($"{resourceName} was destroyed/ruined and yielded nothing!");
            }

            // 2. Spawn Visuals
            if (destroyEffect != null)
            {
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
            }

            // 3. Destroy this object (clearing the terrain)
            Destroy(gameObject);
        }
    }
}