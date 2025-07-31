using UnityEngine;

public class PickupableItem : Interactable
{
    public override float InteractionDistance => 2f; // Default interaction distance for pickupable items

    public string itemName = "Item";

    private void Start()
    {
        interactionPrompt = $"Press E to pick up {itemName}";
    }

    public override void Interact()
    {
        Debug.Log($"Picked up {itemName}");
        CraftingManager.Instance.CollectItem(itemName);
        Destroy(gameObject);
    }
}
