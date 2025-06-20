using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color selectedColor, notSelectedColor;

    public SlotType slotType;
    public EquipmentType equipmentType;

    void Awake()
    {
        Deselect();
    }

    public void Select()
    {
        image.color = selectedColor;
    }

    public void Deselect()
    {
        image.color = notSelectedColor;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            InventoryItem inventoryItem = dropped.GetComponent<InventoryItem>();

            if (slotType == SlotType.InventorySlot)
            {
                inventoryItem.parentAfterDrag = transform;
            } else if (slotType == SlotType.WeaponSlot && inventoryItem.weapon.itemType == ItemType.Weapon)
            {
                inventoryItem.parentAfterDrag = transform;
            }
            
        }
    }

}

public enum SlotType 
{
    WeaponSlot,
    ConsumableSlot,
    EquipmentSlot,
    InventorySlot
}

public enum EquipmentType 
{ 
    none,
    Helmet,
    Chestplate,
    Leggings,
    Boots,
    Accessories
}

