using UnityEngine;
using UnityEngine.UI;

public class CraftingUI : MonoBehaviour
{
    public GameObject craftingMenu;
    public Button craftButton;

    private Item[] inputItems = new Item[3];

    void Start()
    {
        craftButton.onClick.AddListener(Craft);
    }

    public void ToggleCraftingMenu()
    {
        craftingMenu.SetActive(!craftingMenu.activeSelf);
    }

    public void AddItem(Item item, int index)
    {
        inputItems[index] = item;
    }

    private void Craft()
    {
        if (CraftingManager.instance.Craft(inputItems, out Item outputItem))
        {
            Debug.Log("Crafted " + outputItem.name);
        }
        else
        {
            Debug.Log("Crafting failed");
        }
    }
}
