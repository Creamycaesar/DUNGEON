using UnityEngine;

namespace Dungeon.Mechanics
{
    public enum AdvantageState
    {
        Normal,
        Advantage,
        Disadvantage
    }

    /// <summary>
    /// Static utility class for handling all randomized dice rolls in the game.
    /// </summary>
    public static class Dice
    {
        /// <summary>
        /// Rolls a standard XdY dice combination (e.g., Roll(2, 6) for 2d6).
        /// </summary>
        /// <param name="count">Number of dice to roll</param>
        /// <param name="sides">Number of sides on the dice</param>
        /// <returns>The total sum of the roll</returns>
        public static int Roll(int count, int sides)
        {
            int total = 0;
            for (int i = 0; i < count; i++)
            {
                // Random.Range for integers is max-exclusive, so we use sides + 1
                total += Random.Range(1, sides + 1);
            }
            return total;
        }

        /// <summary>
        /// Rolls a standard 1d20, applying Advantage or Disadvantage if necessary.
        /// </summary>
        /// <param name="state">Whether the roll has advantage or disadvantage</param>
        /// <returns>The result of the d20 roll</returns>
        public static int RollD20(AdvantageState state = AdvantageState.Normal)
        {
            int roll1 = Random.Range(1, 21);
            int roll2 = Random.Range(1, 21);

            switch (state)
            {
                case AdvantageState.Advantage:
                    return Mathf.Max(roll1, roll2);
                case AdvantageState.Disadvantage:
                    return Mathf.Min(roll1, roll2);
                case AdvantageState.Normal:
                default:
                    return roll1;
            }
        }

        /// <summary>
        /// Helper function for checking critical hits/misses directly.
        /// </summary>
        public static bool IsCriticalHit(int d20Roll) => d20Roll == 20;
        public static bool IsCriticalMiss(int d20Roll) => d20Roll == 1;
    }
}