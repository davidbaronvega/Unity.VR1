using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class InteractableHoverEvents : MonoBehaviour
{
    public UnityEvent onHandHoverBegin;
    public UnityEvent onHandHoverEnd;
    public UnityEvent onAttachedToHand;
    public UnityEvent onDetachedFromHand;

    private void OnHandHoverBegin()
    {
        onHandHoverBegin.Invoke();
    }

    private void OnHandHoverEnd()
    {
        onHandHoverEnd.Invoke();
    }

    private void OnAttachedToHand(Hand hand)
    {
        onAttachedToHand.Invoke();

        ItemCollector collector = FindObjectOfType<ItemCollector>(); // Find the ItemCollector in the scene
        if (collector != null && collector.ItemPickedUp(gameObject))
        {
            // Destroy the item only if it's the correct one in the sequence
            Destroy(gameObject);
        }
    }

    private void OnDetachedFromHand(Hand hand)
    {
        onDetachedFromHand.Invoke();
    }
}
