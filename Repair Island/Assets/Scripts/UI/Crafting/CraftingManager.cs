using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro

public class CraftingManager : MonoBehaviour
{
    public GameObject craftablePrefab;
    public List<Item> allGameItems;
    List<CraftingUIObject> cratfableUIItems = new List<CraftingUIObject>();

    public void CreateCraftables()
    {
        for (int i = 0; i < allGameItems.Count; i++)
        {
            if (allGameItems[i].canBeCrafted)
            {
                GameObject obj = Instantiate(craftablePrefab, this.transform);
                CraftingUIObject craftable = obj.AddComponent<CraftingUIObject>();
                craftable.craftableItem = allGameItems[i];
                TextMeshProUGUI[] texts = obj.GetComponentsInChildren<TextMeshProUGUI>();
                texts[0].text = allGameItems[i].name;
                texts[1].text = "Description for " + allGameItems[i].name;
                string rep = "";
                for (int j = 0; j < allGameItems[i].recipe.Recipe.Count; j++)
                {

                    if (allGameItems[i].recipe.Recipe[j].resource != PlayerAvailableResources.Resources.NA) //is this recipe piece a resource or item?
                    {
                        //Do we have item?
                        rep += allGameItems[i].recipe.Recipe[j].resource.ToString() + " (" + allGameItems[i].recipe.Recipe[j].count + ") ";
                    }
                    else
                    {
                        //Do we have resources
                        rep += allGameItems[i].recipe.Recipe[j].Item.name + " (" + allGameItems[i].recipe.Recipe[j].count + ") ";
                    }
                }
                texts[2].text = rep;
                cratfableUIItems.Add(craftable);
                if (!craftable.CanCraftItem())
                {
                    craftable.GetComponent<Image>().color = Color.red;
                }
            }
        }
    }

    private void Start()
    {
        CreateCraftables();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            this.gameObject.SetActive(!this.gameObject.activeSelf);
        }
    }

    private void OnEnable()
    {
        foreach (CraftingUIObject c in cratfableUIItems)
        {
            if (!c.CanCraftItem())
            {
                c.GetComponent<Image>().color = Color.red;
            }
        }
    }
}