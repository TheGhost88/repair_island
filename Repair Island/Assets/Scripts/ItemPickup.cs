
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class ItemPickup : Interactable
{
    public AudioClip[] SoundClips;

    private SoundManager sm;

    public Item item;

    public int amountInStack = 0;

    private int zeroHealthChecker;



    public override void Interact(NecessaryItem itemUsed = NecessaryItem.NA)
    {
        base.Interact();

        //Josh: Recommend reducing interactable health so we can remove it when exhausted, obviously things like a water collector we won't want to destroy that
        //Also recommend checking what item the player used on this interactable
        Vector3Int tilePos = tilemap.layoutGrid.WorldToCell(this.gameObject.transform.position);
        tilemap.SetTile(tilePos, ReplacementTileAnimated);
        Pickup();
        health--;
        //if (health <= 0)
            //DestroyImmediate(this);

        zeroHealthChecker = health;
        PlayItemSound();
    }

    //Do code here for whatever you need the item to do when interacted with
    public void Pickup()
    {

        //add item to inventory
        bool wasPickedUp = false;
        Debug.Log("Picking up " + item.name);
        wasPickedUp = Inventory.instance.Add(item);
        if (item.stackable)
        {
            Inventory.instance.AddToStack(item, amountInStack);
            PlayerResources.Instance.availableResources.AddResource(item.resourceType, amountInStack);
        }
        
    }

    public void PlayItemSound()
    {
        if(item.name == "Wood")
        {
            if(zeroHealthChecker <= 0)
            {
                sm.PlaySingleSound(SoundClips[3]);
            }
            else
            {
                sm.PlaySingleSound(SoundClips[0]);
            }
        }
        else if (item.name == "Metal")
        {
            if (zeroHealthChecker <= 0)
            {
                sm.PlaySingleSound(SoundClips[4]);
            }
            else
            {
                sm.PlaySingleSound(SoundClips[1]);
            }
        }
        else if (item.name == "Fiber")
        {
            sm.PlaySingleSound(SoundClips[2]);
        }
        else
        {
            // If we are not picking any of the
            // previous options, then what
            // are we picking up?
        }
    }
}
