
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus = false;
    //Transform player;

    [Header("Spawner Properties")]
    public int health;
    public enum NecessaryItem { NA = 0, Sword, Axe, Hammer, Pickaxe, Sythe, Shovel }
    public NecessaryItem neededItem;

    bool hasInteracted = false;

    public virtual void Interact(NecessaryItem itemUsed = NecessaryItem.NA) //by default we don't check for a tool
    {
        //This is method is meant to be overwritten
        Debug.Log("Interacting with " + transform.name);

    }

    //JOSH NOTE: when enemies are in the game we will want to prioritize them over other objects
    public float GetDistanceFromPlayer(Transform player)
    {
        return Vector3.Distance(player.position, interactionTransform.position);
    }

    private void Update()
    {
        //if (isFocus && !hasInteracted)
        //{
        //    float distance = Vector3.Distance(player.position, interactionTransform.position);
        //    if(distance <= radius)
        //    {
        //        //Interact();
        //        //hasInteracted = true;
        //    }
        //}
    }

    //public void OnFocused(Transform playerTransform)
    //{
    //    isFocus = true;
    //    player = playerTransform;
    //}

    //public void OnDefocused()
    //{
    //    isFocus = false;
    //    player = null;
    //    hasInteracted = false;
    //}

    private void OnDrawGizmosSelected()
    {
        if(interactionTransform == null)
        {
            interactionTransform = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
