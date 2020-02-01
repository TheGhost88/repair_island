﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton_ish
    public static Inventory instance;
    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found");
            return;
        }
        instance = this;
    }
    #endregion
        
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 10;
    public int maxItemsInStack = 100;

    public List<Item> items = new List<Item>();
    public List<int> itemsInSlot = new List<int>();

    public void Start()
    {
        //empty for now
        //Could do some audio or other item setup here
    }
       
    public bool Add(Item item)
    {
        if (item != item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Inventory Full");
                return false;
            }

            if (item.stackable == false)
            {
                items.Add(item);
                itemsInSlot.Add(1);
            }

            if (HasItem(item) == false && item.stackable == true)
            {
                items.Add(item);
                itemsInSlot.Add(0);
            }

            item.equipmentManager = GetComponent<EquipmentManager>();
            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }
        //Increment playerResource
        return true;
    }

    public void AddToStack(Item item, int amount)
    {
        int index = items.IndexOf(item);
        Debug.Log(item.name + " is in slot " + index);

        itemsInSlot[index] += amount;

        if ((itemsInSlot[index] + amount) >= maxItemsInStack)
        {
            itemsInSlot[index] = maxItemsInStack;
        }

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void Remove(Item item)
    {
       
        int index = items.IndexOf(item);
        itemsInSlot.RemoveAt(index);
        
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    private bool HasItem(Item item)
    {
        return items.Exists(i => i == item);
    }

    //Josh (todo)
    //Items that are resources (wood, metal, food) we may want to evaluate them when picked up and add them to a global 
    //list so we don't have to go through the entire inventory list when crafting (See PlayerResources) also remove them when used/dropped
}
