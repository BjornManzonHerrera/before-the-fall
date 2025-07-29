using UnityEngine;

public abstract class Interactable : MonoBehaviour, IInteractable
{
    // Forcing recompilation


    public string interactionPrompt = "Interact";

    public string GetInteractionPrompt()
    {
        return interactionPrompt;
    }

    public string GetDescription()
    {
        return ""; // Default empty description
    }

    public abstract float InteractionDistance { get; }

    public abstract void Interact();
}