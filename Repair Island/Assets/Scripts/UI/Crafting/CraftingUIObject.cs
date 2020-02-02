using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingUIObject : MonoBehaviour
{
    public Item craftableItem;

    public Button craftButton;

    private void Start()
    {
        craftButton = GetComponentInChildren<Button>();
        craftButton.onClick.AddListener(CraftButtonOnClick);
    }

    public bool CanCraftItem()
    {

        for( int i = 0; i < craftableItem.recipe.Recipe.Count; i++)
        {
           if( craftableItem.recipe.Recipe[i].resource != PlayerAvailableResources.Resources.NA) //is this recipe piece a resource or item?
            {
                //Do we have the resources?

                if (PlayerResources.Instance.availableResources.GetResourceCount(craftableItem.recipe.Recipe[i].resource) < craftableItem.recipe.Recipe[i].count)
                    return false;
            }
           else
            {
                //Do we have the item?
                if (!Inventory.instance.HasItem(craftableItem.recipe.Recipe[i].Item))
                    return false;
            }
        }
        return true;
    }

    void CraftButtonOnClick()
    {
        CraftItem();
    }

    public void CraftItem()
    {
        // Remove crafting recipe items/resources from inventory
        if (CanCraftItem())
        {
            Inventory.instance.Add(craftableItem);
            if (craftableItem.stackable)
            {
                Inventory.instance.AddToStack(craftableItem, 1);
            }
            for (int i = 0; i < craftableItem.recipe.Recipe.Count; i++)
            {
                Inventory inventory = Inventory.instance;
                inventory.RemoveFromStack(craftableItem.recipe.Recipe[i].Item, craftableItem.recipe.Recipe[i].count);
                int index = inventory.items.IndexOf(craftableItem.recipe.Recipe[i].Item);
                if ((inventory.itemsInSlot[index] - craftableItem.recipe.Recipe[i].count) <=0)
                    inventory.Remove(craftableItem.recipe.Recipe[i].Item);
                
                PlayerResources.Instance.availableResources.UseResource(craftableItem.recipe.Recipe[i].Item.resourceType, craftableItem.recipe.Recipe[i].count);
            }
        }
    }
}
