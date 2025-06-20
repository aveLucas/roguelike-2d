using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickup;
    public Weapon[] weaponsToPickup;

    public void PickUpItem(int id)
    {
        //inventoryManager.AddItem(itemsToPickup[id]);
        inventoryManager.AddWeapon(weaponsToPickup[id]);
    }

    public void GetSelectedItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(false);
        if (receivedItem != null)
        {
            Debug.Log($"Item selecionado: {receivedItem.name}");
        }
    }

    public void UseSelectedItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(true);
        if (receivedItem != null)
        {
            Debug.Log($"Item usado: {receivedItem.name}");
        }

    }
}
