using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);

            
            if (obj != null)
            {
                var itemIcon = obj.transform.Find("ItemIcon")?.GetComponent<Image>();
                var itemName = obj.transform.Find("ItemName")?.GetComponent<TextMeshProUGUI>();

                
                if (itemIcon != null && itemName != null)
                {
                    itemName.text = item.itemName;
                    itemIcon.sprite = item.icon;
                }
                else
                {
                    Debug.LogError("ItemIcon or ItemName not found on InventoryItem prefab.");
                }
            }
            else
            {
                Debug.LogError("Failed to instantiate InventoryItem prefab.");
            }
        }
    }
}

