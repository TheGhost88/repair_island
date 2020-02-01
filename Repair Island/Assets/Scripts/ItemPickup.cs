﻿
using System;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    private void Pickup()
    {

        //add item to inventory
        Debug.Log("Picking up " + item.name);
        Destroy(gameObject);
    }
}
