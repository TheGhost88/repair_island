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
    }
}

public class PlayerAvailableResources
    {
    public enum Resources { Wood= 0, metal, fruit, };
    public int wood;
    public int metal;
    public int fruit;
        //etc...
        public int GetResourceCount(Resources resource)
    {
        //Todo finish switch case
        switch (resource)
        {
            case Resources.Wood:
                return wood;
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