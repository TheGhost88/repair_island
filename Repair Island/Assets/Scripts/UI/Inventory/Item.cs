using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public PlayerAvailableResources.Resources resourceType;
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public bool stackable = false;

    public EquipmentManager equipmentManager;

    public virtual void Use()
    {
        Debug.Log("Using" + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}