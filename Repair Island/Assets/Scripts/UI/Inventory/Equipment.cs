using UnityEngine;
[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;

    private Inventory inventory;

    public int damageModifier;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);    

        if (!equipmentManager.IsItemEquipped(this))
            equipmentManager.Equip(this);
        RemoveFromInventory();
        equipmentManager.inventory.onItemChangedCallback.Invoke();
    }
}

public enum EquipmentSlot { primaryWeapon, primaryPotion }