﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPickup : MonoBehaviour
{
    public Item Item;


    public void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        SoundManager.Instance.Play("item_get");

        Destroy(gameObject);
    }


    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        Pickup();
    }
}
