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


}
