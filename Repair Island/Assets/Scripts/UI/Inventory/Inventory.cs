using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [HideInInspector]
    public EquipmentManager equipmentManager;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 10;

    public List<Item> items = new List<Item>();
    public List<int> itemsInSlot = new List<int>();

    public void Start()
    {
        //empty for now
        //Could do some audio or other item setup here
    }

    public void Awake()
    {
        equipmentManager = GetComponent<EquipmentManager>();
    }

    public bool Add(Item item)
    {
        if(item != item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Inventory Full");
                return false;
            }

            if(item.stackable == false)
            {
                items.Add(item);
                itemsInSlot.Add(1);
            }

            if(HasItem(item) == false && item.stackable == true)
            {
                items.Add(item);
                itemsInSlot.Add(0);
            }

            item.equipmentManager = GetComponent<EquipmentManager>();
            if(onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }
        return true;
    }

    private bool HasItem(Item item)
    {
        return items.Exists(i => i == item);
    }
}
