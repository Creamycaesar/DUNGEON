using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon.Mechanics
{
    public enum TurnState
    {
        PlayerTurn,
        EnemyTurn
    }

    /// <summary>
    /// Interface that any non-player entity (Enemy, Trap, NPC) must implement 
    /// if it wants to act during the Enemy Phase.
    /// </summary>
    public interface ITurnActor
    {
        /// <summary>
        /// Executes the actor's logic for the turn. 
        /// Because it's an IEnumerator, the actor can yield return new WaitForSeconds() 
        /// while grid movement or attack animations play out.
        /// </summary>
        IEnumerator TakeTurn();
    }

    /// <summary>
    /// Central clock/state machine for the game. 
    /// Handles the "Player Act -> Enemy Act" loop (Phase 3 of GDD).
    /// </summary>
    public class TurnManager : MonoBehaviour
    {
        // Singleton pattern makes it easy for the PlayerController to call TurnManager.Instance.EndPlayerTurn()
        public static TurnManager Instance { get; private set; }

        public TurnState CurrentState { get; private set; } = TurnState.PlayerTurn;

        // Events that other scripts (like UI, buff trackers, or traps) can subscribe to
        public event Action OnPlayerTurnStart;
        public event Action OnEnemyTurnStart;

        // Registry of all active actors in the current level
        private List<ITurnActor> _turnActors = new List<ITurnActor>();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        /// <summary>
        /// Call this from an enemy's Start() or spawn logic so they are added to the turn order.
        /// </summary>
        public void RegisterActor(ITurnActor actor)
        {
            if (!_turnActors.Contains(actor))
            {
                _turnActors.Add(actor);
            }
        }

        /// <summary>
        /// Call this from an enemy's Die() logic so they stop taking turns.
        /// </summary>
        public void UnregisterActor(ITurnActor actor)
        {
            if (_turnActors.Contains(actor))
            {
                _turnActors.Add(actor);
                _turnActors.Remove(actor);
            }
        }

        /// <summary>
        /// Called by the PlayerController after the player successfully moves, attacks, or uses an item.
        /// </summary>
        public void EndPlayerTurn()
        {
            // Prevent ending the turn if it's already the enemy's turn
            if (CurrentState != TurnState.PlayerTurn) return;

            CurrentState = TurnState.EnemyTurn;

            // Fire event for anything that needs to know the enemy phase is starting (e.g., closing UI)
            OnEnemyTurnStart?.Invoke();

            StartCoroutine(EnemyPhaseRoutine());
        }

        /// <summary>
        /// Loops through all registered actors and lets them take their turn sequentially.
        /// </summary>
        private IEnumerator EnemyPhaseRoutine()
        {
            // Clean up any nulls in case actors were destroyed without unregistering
            _turnActors.RemoveAll(actor => actor == null || actor.Equals(null));

            // Execute each actor's turn one by one
            foreach (var actor in _turnActors)
            {
                // We yield on the actor's routine. The loop will pause here until 
                // the specific enemy finishes moving, playing its attack animation, etc.
                yield return StartCoroutine(actor.TakeTurn());

                // Add a tiny buffer between enemy actions for visual clarity
                yield return new WaitForSeconds(0.05f);
            }

            // Once all enemies have acted, hand control back to the player
            StartPlayerTurn();
        }

        private void StartPlayerTurn()
        {
            CurrentState = TurnState.PlayerTurn;

            // Fire event so the PlayerController knows it can accept input again, 
            // and so buffs/debuffs can tick down their durations.
            OnPlayerTurnStart?.Invoke();
        }
    }
}