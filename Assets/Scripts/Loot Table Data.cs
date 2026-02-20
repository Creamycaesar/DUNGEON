using UnityEngine;
using System.Collections.Generic;

namespace DUNGEON.Data
{
    [System.Serializable]
    public class LootEntry
    {
        public ItemSO item;
        [Tooltip("Higher number = Higher chance to drop")]
        public int weight = 10;
    }

    [CreateAssetMenu(fileName = "NewLootTable", menuName = "DUNGEON/Items/Loot Table")]
    public class LootTableSO : ScriptableObject
    {
        public string tableID; // e.g., "Tier1_Chest" or "Goblin_Drops"
        public List<LootEntry> lootList;

        // Logic to pick a random item based on weights
        public ItemSO GetRandomLoot()
        {
            if (lootList == null || lootList.Count == 0) return null;

            int totalWeight = 0;
            foreach (var entry in lootList)
            {
                totalWeight += entry.weight;
            }

            int randomValue = Random.Range(0, totalWeight);
            int currentWeight = 0;

            foreach (var entry in lootList)
            {
                currentWeight += entry.weight;
                if (randomValue < currentWeight)
                {
                    return entry.item;
                }
            }

            return lootList[0].item; // Fallback
        }
    }
}