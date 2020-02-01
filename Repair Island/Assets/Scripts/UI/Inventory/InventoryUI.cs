
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    Inventory inventory;

    InventorySlot[] slots;
  
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = GetComponentsInChildren<InventorySlot>();
    }

    void Update()
    {
        
    }

    void UpdateUI()
    {
        Debug.Log("updating UI");
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
                slots[i].AddToNumberInSlot(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
