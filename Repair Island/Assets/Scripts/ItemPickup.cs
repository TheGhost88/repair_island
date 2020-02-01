
using System;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public int amountInStack = 0;

    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    private void Pickup()
    {

        //add item to inventory
        bool wasPickedUp = false;
        Debug.Log("Picking up " + item.name);
        wasPickedUp = Inventory.instance.Add(item);
        if (item.stackable)
        {
            Inventory.instance.AddToStack(item, amountInStack);
        }
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
