<<<<<<< HEAD
﻿using System.Collections.Generic;
using System;
using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> parent of 3ff5fe6... Start of Craftable system

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public PlayerAvailableResources.Resources resourceType;
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public bool stackable = false;

    public EquipmentManager equipmentManager;
<<<<<<< HEAD

    public bool canBeCrafted;
    public RecipeHolder recipe;
=======
>>>>>>> parent of 3ff5fe6... Start of Craftable system

    public virtual void Use()
    {
        Debug.Log("Using" + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
<<<<<<< HEAD

}
[System.Serializable]
public class RecipeHolder
{
    public List<Recipe> Recipe = new List<Recipe>();
}
[System.Serializable]
public class Recipe
{
    public PlayerAvailableResources.Resources resource;
    public Item Item;
    public int count;
=======
>>>>>>> parent of 3ff5fe6... Start of Craftable system
}