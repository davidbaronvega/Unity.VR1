//David Baron-Vega, GF7068

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Valve.VR.InteractionSystem
{
    public class ItemCollector : MonoBehaviour
    {
        public GameObject[] itemsInOrder; // Assign in the inspector, in the required order
        private int currentItemIndex = 0;

        public TeleportPoint lockedTeleportPoint; // Assign the locked teleport point in the inspector

        // This function now returns true if the item picked up is the correct one in sequence.
        public bool ItemPickedUp(GameObject item)
        {
            // Check if the item picked up is the correct one in the sequence
            if (currentItemIndex < itemsInOrder.Length && item == itemsInOrder[currentItemIndex])
            {
                Debug.Log($"Correct item picked: {item.name}");
                currentItemIndex++; // Move to the next item in the sequence

                // Check if all items have been collected
                if (currentItemIndex >= itemsInOrder.Length)
                {
                    Debug.Log("All items collected in order!");
                    UnlockTeleportPoint();
                }
                return true; // The correct item was picked up
            }
            else
            {
                // If the wrong item is picked, give feedback to the player
                Debug.Log($"Incorrect item picked. You picked {item.name}, but should pick {itemsInOrder[currentItemIndex].name}");
                return false; // The incorrect item was picked up, do not destroy it
            }
        }

        private void UnlockTeleportPoint()
        {
            if (lockedTeleportPoint != null)
            {
                lockedTeleportPoint.locked = false; // Assuming there's a 'locked' public bool in your TeleportPoint script
                Debug.Log("Teleport point unlocked!");
            }
        }
    }
}