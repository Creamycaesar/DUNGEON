using System.Collections.Generic;
using UnityEngine;

namespace Dungeon.Mechanics
{
    /// <summary>
    /// Holds the raw stats for an entity (Player, Enemy, Boss). 
    /// This can be attached to a MonoBehaviour or used inside a ScriptableObject.
    /// </summary>
    [System.Serializable]
    public class StatBlock
    {
        [Header("Progression")]
        public int Level = 1;

        [Header("Ability Scores")]
        [Range(1, 30)] public int Strength = 10;
        [Range(1, 30)] public int Dexterity = 10;
        [Range(1, 30)] public int Constitution = 10;
        [Range(1, 30)] public int Intelligence = 10;
        [Range(1, 30)] public int Wisdom = 10;
        [Range(1, 30)] public int Charisma = 10;

        [Header("Proficiencies")]
        public List<Ability> SavingThrowProficiencies = new List<Ability>();
        public List<Skill> SkillProficiencies = new List<Skill>();

        // Quick properties to fetch modifiers dynamically based on current raw scores
        public int StrMod => RulesEngine.GetModifier(Strength);
        public int DexMod => RulesEngine.GetModifier(Dexterity);
        public int ConMod => RulesEngine.GetModifier(Constitution);
        public int IntMod => RulesEngine.GetModifier(Intelligence);
        public int WisMod => RulesEngine.GetModifier(Wisdom);
        public int ChaMod => RulesEngine.GetModifier(Charisma);

        public int ProficiencyBonus => RulesEngine.GetProficiencyBonus(Level);

        /// <summary>
        /// Helper to get the modifier for an arbitrary ability enum.
        /// </summary>
        public int GetAbilityModifier(Ability ability)
        {
            switch (ability)
            {
                case Ability.Strength: return StrMod;
                case Ability.Dexterity: return DexMod;
                case Ability.Constitution: return ConMod;
                case Ability.Intelligence: return IntMod;
                case Ability.Wisdom: return WisMod;
                case Ability.Charisma: return ChaMod;
                default: return 0;
            }
        }

        /// <summary>
        /// Rolls a Skill Check (e.g., a Stealth check to avoid a trap).
        /// </summary>
        /// <param name="skill">The skill being tested</param>
        /// <param name="advState">Normal, Advantage, or Disadvantage</param>
        /// <returns>The final computed total of the roll</returns>
        public int RollSkillCheck(Skill skill, AdvantageState advState = AdvantageState.Normal)
        {
            int d20Roll = Dice.RollD20(advState);
            Ability baseAbility = RulesEngine.GetBaseAbilityForSkill(skill);
            int abilityMod = GetAbilityModifier(baseAbility);

            int profBonus = SkillProficiencies.Contains(skill) ? ProficiencyBonus : 0;

            int total = d20Roll + abilityMod + profBonus;

            // Optional Debugging (Comment out in production)
            // Debug.Log($"Rolled {skill} Check: {d20Roll} (d20) + {abilityMod} ({baseAbility} mod) + {profBonus} (prof) = {total}");

            return total;
        }

        /// <summary>
        /// Rolls a Saving Throw (e.g., a DEX save against a fireball trap).
        /// </summary>
        public int RollSavingThrow(Ability ability, AdvantageState advState = AdvantageState.Normal)
        {
            int d20Roll = Dice.RollD20(advState);
            int abilityMod = GetAbilityModifier(ability);

            int profBonus = SavingThrowProficiencies.Contains(ability) ? ProficiencyBonus : 0;

            int total = d20Roll + abilityMod + profBonus;
            return total;
        }

        /// <summary>
        /// Rolls a generic Ability Check (e.g., raw Strength to push a boulder).
        /// </summary>
        public int RollAbilityCheck(Ability ability, AdvantageState advState = AdvantageState.Normal)
        {
            int d20Roll = Dice.RollD20(advState);
            int abilityMod = GetAbilityModifier(ability);

            // Note: Standard D&D raw ability checks do not use proficiency bonus!
            return d20Roll + abilityMod;
        }

        /// <summary>
        /// Base Attack Roll logic: d20 + Ability Modifier + Proficiency Bonus (if proficient).
        /// </summary>
        private int RollBaseAttack(Ability ability, bool isProficient, AdvantageState advState)
        {
            int d20Roll = Dice.RollD20(advState);
            int abilityMod = GetAbilityModifier(ability);
            int profBonus = isProficient ? ProficiencyBonus : 0;

            return d20Roll + abilityMod + profBonus;
        }

        /// <summary>
        /// Rolls a Melee Attack. Typically uses Strength (or Dexterity for Finesse weapons).
        /// </summary>
        public int RollMeleeAttack(Ability attackAbility = Ability.Strength, bool isProficient = true, AdvantageState advState = AdvantageState.Normal)
        {
            return RollBaseAttack(attackAbility, isProficient, advState);
        }

        /// <summary>
        /// Rolls a Ranged Attack. Typically uses Dexterity (or Strength for Thrown weapons).
        /// </summary>
        public int RollRangedAttack(Ability attackAbility = Ability.Dexterity, bool isProficient = true, AdvantageState advState = AdvantageState.Normal)
        {
            return RollBaseAttack(attackAbility, isProficient, advState);
        }

        /// <summary>
        /// Rolls a Melee Spell Attack. Always uses the caster's spellcasting ability and includes their proficiency bonus.
        /// </summary>
        public int RollMeleeSpellAttack(Ability spellcastingAbility, AdvantageState advState = AdvantageState.Normal)
        {
            // Spell attacks always include proficiency bonus
            return RollBaseAttack(spellcastingAbility, true, advState);
        }

        /// <summary>
        /// Rolls a Ranged Spell Attack. Always uses the caster's spellcasting ability and includes their proficiency bonus.
        /// </summary>
        public int RollRangedSpellAttack(Ability spellcastingAbility, AdvantageState advState = AdvantageState.Normal)
        {
            // Spell attacks always include proficiency bonus
            return RollBaseAttack(spellcastingAbility, true, advState);
        }
    }
}