using UnityEngine;

public class Altar : MonoBehaviour, IInteractable
{
    public string InteractionPrompt => "Open Crafting Menu";
    public float InteractionDistance => 2f;

    public CraftingUI craftingUI;

    public void Interact()
    {
        craftingUI.ToggleCraftingMenu();
    }

    public string GetDescription()
    {
        return "An ancient altar. It seems to have some power.";
    }
}
