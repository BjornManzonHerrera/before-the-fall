using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public static CraftingManager Instance { get; private set; }

    public List<string> requiredItems = new List<string> { "Item1", "Item2", "Item3" };
    private List<string> collectedItems = new List<string>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void CollectItem(string itemName)
    {
        if (!collectedItems.Contains(itemName))
        {
            collectedItems.Add(itemName);
        }
    }

    public bool CheckRequiredItems()
    {
        return new HashSet<string>(collectedItems).SetEquals(requiredItems);
    }
}
