using UnityEngine;

namespace Dungeon.Mechanics
{
    public enum Ability
    {
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma
    }

    public enum Skill
    {
        Acrobatics, AnimalHandling, Arcana, Athletics, Deception, History, Insight,
        Intimidation, Investigation, Medicine, Nature, Perception, Performance,
        Persuasion, Religion, SleightOfHand, Stealth, Survival
    }

    /// <summary>
    /// Static utility to handle core D&D 5e formulas and rule mappings.
    /// </summary>
    public static class RulesEngine
    {
        /// <summary>
        /// Calculates the standard D&D ability modifier (e.g., 10 is +0, 12 is +1, 8 is -1).
        /// </summary>
        public static int GetModifier(int abilityScore)
        {
            return Mathf.FloorToInt((abilityScore - 10) / 2f);
        }

        /// <summary>
        /// Calculates proficiency bonus based on total character level.
        /// Scales correctly for Lvl 1-20: +2 at Lvl 1, +3 at Lvl 5, +4 at Lvl 9, etc.
        /// </summary>
        public static int GetProficiencyBonus(int level)
        {
            return 1 + Mathf.CeilToInt(level / 4f);
        }

        /// <summary>
        /// Maps a specific skill to its base primary attribute.
        /// Useful for automatically pulling the right modifier during a skill check.
        /// </summary>
        public static Ability GetBaseAbilityForSkill(Skill skill)
        {
            switch (skill)
            {
                case Skill.Athletics:
                    return Ability.Strength;
                case Skill.Acrobatics:
                case Skill.SleightOfHand:
                case Skill.Stealth:
                    return Ability.Dexterity;
                case Skill.Arcana:
                case Skill.History:
                case Skill.Investigation:
                case Skill.Nature:
                case Skill.Religion:
                    return Ability.Intelligence;
                case Skill.AnimalHandling:
                case Skill.Insight:
                case Skill.Medicine:
                case Skill.Perception:
                case Skill.Survival:
                    return Ability.Wisdom;
                case Skill.Deception:
                case Skill.Intimidation:
                case Skill.Performance:
                case Skill.Persuasion:
                    return Ability.Charisma;
                default:
                    return Ability.Strength; // Fallback
            }
        }
    }
}