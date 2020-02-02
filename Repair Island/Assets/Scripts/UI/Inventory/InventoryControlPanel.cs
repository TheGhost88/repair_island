using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryControlPanel : MonoBehaviour
{

    private PlayerMovement player;

    

    Inventory inventory;

    InventorySlot inventorySlot;

    public GameObject itemPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        inventory = Inventory.instance;
        inventorySlot = GetComponentInParent<InventorySlot>();
        player = GameObject.FindObjectOfType<PlayerMovement>();
        

    }

    public void DropItemAtLocation()
    {
        Item item = inventorySlot.item;
        Transform dropLocation = player.gameObject.GetComponentInChildren<DropLocation>().gameObject.transform;

        ItemPickup itemPickup = itemPrefab.GetComponent<ItemPickup>();
        SpriteRenderer itemIcon = itemPrefab.GetComponent<SpriteRenderer>();
        itemPickup.item = item;
        itemIcon.sprite = itemPickup.item.icon;
        itemPrefab.gameObject.name = item.name;

        Instantiate(itemPrefab, dropLocation.position, dropLocation.rotation); 

        //remove item from inventory
        int index = inventory.items.IndexOf(item);
        inventory.RemoveFromStack(item, 1);
        if(inventory.itemsInSlot[index] <= 0)
        {
            inventory.Remove(item);
        }

    }
}
