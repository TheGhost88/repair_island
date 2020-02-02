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
        Instantiate(itemPrefab, dropLocation.position, dropLocation.rotation);
        ItemPickup itemPickup = itemPrefab.GetComponent<ItemPickup>();
        SpriteRenderer itemIcon = itemPrefab.GetComponent<SpriteRenderer>();
        itemPickup.item = item;
        itemIcon.sprite = itemPickup.item.icon;
        itemPrefab.gameObject.name = item.name;


    }
}
