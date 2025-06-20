using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    

    [Header("UI")]
    public Image image;
    public Text countText;
    public Transform canvasTransform;

    [HideInInspector] public Item item;
    [HideInInspector] public Weapon weapon;
    [HideInInspector] public int count = 1;
    [HideInInspector] public Transform parentAfterDrag;

    public void InitializeItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        canvasTransform = GameObject.Find("PlayerUI").transform;
        RefreshCount();
    }

    public void InitializeWeapon(Weapon newWeapon)
    {
        weapon = newWeapon;
        image.sprite = newWeapon.image;
        canvasTransform = GameObject.Find("PlayerUI").transform;
        RefreshCount();
    }

    public void RefreshCount()
    {
        countText.text = count.ToString();

        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(canvasTransform);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
}
