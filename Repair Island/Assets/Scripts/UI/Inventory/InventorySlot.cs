using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    public TextMeshProUGUI itemName;

    [SerializeField]
    private Button thisItemButton;

    [SerializeField]
    private TextMeshProUGUI numberOfItemsInSlotDisplay;

    int numberOfIemsInStack = 0;

    Inventory inventory;

    Item item;



    private void Awake()
    {
        
        itemName.text = "Empty";
        numberOfItemsInSlotDisplay.text = numberOfIemsInStack.ToString();

    }
    private void Start()
    {
        inventory = Inventory.instance; 
    }

    private void Update()
    {
        if(item == null)
        {
            numberOfItemsInSlotDisplay.enabled = false;
        }
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
        itemName.text = item.name;
    }

    public void AddToNumberInSlot(Item newItem)
    {
        item = newItem;
        int index = inventory.items.IndexOf(item);
        numberOfIemsInStack = inventory.itemsInSlot[index];
        numberOfItemsInSlotDisplay.enabled = true;

        if(numberOfIemsInStack <= 1)
        {
            numberOfItemsInSlotDisplay.text = "";
        }
        else
        {
            numberOfItemsInSlotDisplay.text = numberOfIemsInStack.ToString();
        }
        //inventory.onItemChangedCallback.Invoke();
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
        itemName.text = "Empty";
        numberOfIemsInStack = 0;
        numberOfItemsInSlotDisplay.text = numberOfIemsInStack.ToString();
        numberOfItemsInSlotDisplay.enabled = false;
    }

    public void OnRemoveButton()
    {
        if (item.stackable)
        {

        }
        inventory.Remove(item);
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }
}
