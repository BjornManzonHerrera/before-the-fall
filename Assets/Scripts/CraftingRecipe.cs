using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Inventory/Crafting Recipe")]
public class CraftingRecipe : ScriptableObject
{
    public Item[] inputItems;
    public Item outputItem;
}
