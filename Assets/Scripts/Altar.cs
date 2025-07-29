using UnityEngine;
using UnityEngine.InputSystem;

public class Altar : Interactable
{
    public override float InteractionDistance => 3f; // Example distance for the altar

    private bool canCraft = false;

    private void Start()
    {
        interactionPrompt = "The altar is dormant.";
    }

    private void Update()
    {
        if (canCraft)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                Debug.Log("You have chosen to summon the Old One.");
                // Add logic to trigger the "bad" ending
            }
            else if (Keyboard.current.fKey.wasPressedThisFrame)
            {
                Debug.Log("You have chosen to save the world.");
                // Add logic to trigger the "good" ending
            }
        }
    }

    public override void Interact()
    {
        if (CraftingManager.Instance.CheckRequiredItems())
        {
            canCraft = true;
            interactionPrompt = "Press E to Summon the Old One, or F to Save the World";
        }
        else
        {
            Debug.Log("You are missing items to activate the altar.");
        }
    }
}
