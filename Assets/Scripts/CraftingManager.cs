using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public static CraftingManager instance;

    public CraftingRecipe[] recipes;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of CraftingManager found!");
            return;
        }
        instance = this;
    }

    public bool Craft(Item[] inputItems, out Item outputItem)
    {
        foreach (CraftingRecipe recipe in recipes)
        {
            if (CheckRecipe(recipe, inputItems))
            {
                outputItem = recipe.outputItem;
                return true;
            }
        }

        outputItem = null;
        return false;
    }

    private bool CheckRecipe(CraftingRecipe recipe, Item[] inputItems)
    {
        if (recipe.inputItems.Length != inputItems.Length)
        {
            return false;
        }

        for (int i = 0; i < recipe.inputItems.Length; i++)
        {
            if (recipe.inputItems[i] != inputItems[i])
            {
                return false;
            }
        }

        return true;
    }
}