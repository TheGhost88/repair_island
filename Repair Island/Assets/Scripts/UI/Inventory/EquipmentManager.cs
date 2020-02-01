using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public GameObject Player;

    public EquipmentUI equipmentUI;

    public Inventory inventory;

    Equipment[] currentEquipment;

    public Equipment[] GetCurrentEquipment()
    {
        return currentEquipment;
    }

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    private void Start()
    {
        int numberOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numberOfSlots];
        inventory = GetComponent<Inventory>();

        for(int i=0; i<currentEquipment.Length; i++)
        {
            equipmentUI.equipmentSlotDisplays[i].equipmentIcon.enabled = false;
        }
    }

    public bool IsItemEquipped(Equipment item)
    {
        return currentEquipment[(int)item.equipSlot] == item;
    }

    public void Equip(Equipment newItem)
    {
        newItem.equipmentManager = this;
        int slotIndex = (int)newItem.equipSlot;

        int index = inventory.items.IndexOf(newItem);

        Equipment oldItem = null;

        if(currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        if (newItem.stackable)
        {
            equipmentUI.equipmentSlotDisplays[slotIndex].numberOfItemsInStack = null;
        }
    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];

            if(slotIndex == 0 || slotIndex == 1)
            {
                inventory.Add(oldItem);
            }

            currentEquipment[slotIndex] = null;

            if(onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
            equipmentUI.equipmentSlotDisplays[slotIndex].equipmentIcon.enabled = false;
            equipmentUI.equipmentSlotDisplays[slotIndex].equipmentIcon.sprite = null;
            equipmentUI.equipmentSlotDisplays[slotIndex].equipmentIcon.itemName.text = "Empty";
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
            if(equipmentUI.equipmentSlotDisplays[i].numberOfItemsInStack != null)
            {
                equipmentUI.equipmentSlotDisplays[i].numberOfItemsInStack.text = "";
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }
}
