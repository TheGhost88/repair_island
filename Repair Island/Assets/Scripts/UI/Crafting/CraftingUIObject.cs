
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingUIObject : MonoBehaviour
{
    public Item craftableItem;


    public bool CanCraftItem()
    {

        for (int i = 0; i < craftableItem.recipe.Recipe.Count; i++)
        {
            if (craftableItem.recipe.Recipe[i].resource != PlayerAvailableResources.Resources.NA) //is this recipe piece a resource or item?
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

    public void CraftItem()
    {
        // Remove crafting recipe items/resources from inventory
    }
}