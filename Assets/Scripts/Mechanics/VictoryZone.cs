using Platformer.Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Marks a trigger as a VictoryZone, usually used to end the current game level.
    /// </summary>
    public class VictoryZone : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                var ev = Schedule<PlayerEnteredVictoryZone>();
                ev.victoryZone = this;

                StartCoroutine(
                    EndLevelCoroutine()
                );
            }
        }

        IEnumerator EndLevelCoroutine()
        {
            yield return new WaitForSeconds(3);

            SceneManager.LoadScene(
                (int)SceneIndexes.MenuScene    
            );
        }
    }
}