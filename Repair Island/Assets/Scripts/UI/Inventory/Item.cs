using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public PlayerAvailableResources.Resources resourceType;
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
   
    public bool stackable = false;

    public EquipmentManager equipmentManager;
    public bool canBeCrafted;
    public RecipeHolder recipe;

    public virtual void Use()
    {
        Debug.Log("Using" + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
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
}