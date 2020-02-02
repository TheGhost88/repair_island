using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds player resources, inventory, etc...
/// </summary>
public class PlayerResources : MonoBehaviour
{
    public static PlayerResources Instance = null;
    public Inventory playerInventory;
    public PlayerAvailableResources availableResources;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Instance.Init();
        }
        else
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Init()
    {
        playerInventory = Inventory.instance;
        availableResources = new PlayerAvailableResources();
    }
}
[System.Serializable]
public class PlayerAvailableResources
    {
     public enum Resources {NA = 0, Wood, Metal, Fruit, Veggie, Meat, Fiber };
    public int wood;
    public int metal;
    public int fruit;

    public int veggie;
    public int meat;
    public int fiber;

    public PlayerAvailableResources()
    {
        wood = metal = fruit = veggie = meat = fiber = 10;
    }

    //etc...
    public int GetResourceCount(Resources resource)
    {
        //Todo finish switch case
        switch (resource)
        {
            case Resources.Wood:
                return wood;
            case Resources.Metal:
                return metal;
            case Resources.Fiber:
                return fiber;
            case Resources.Fruit:
                return fruit;
            case Resources.Veggie:
                return veggie;
            case Resources.Meat:
                return meat;
        }
        return 0;
    }
    public void AddResource(Resources resource, int value)
    {
        //Todo finish switch case
        switch (resource)
        {
            case Resources.Wood:
                 wood += value;
                break;
            case Resources.Metal:
                metal += value;
                break;
        }
    }
    public void UseResource(Resources resource, int value)
    {
        //Todo finish switch case
        switch (resource)
        {
            case Resources.Wood:
                wood -= value;
                break;
        }
    }
}