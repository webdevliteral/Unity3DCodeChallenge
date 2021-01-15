using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        //equip item
        EquipmentManager.instance.Equip(this);
        //remove from inv
        RemoveFromInventory();
    }
}

public enum EquipmentSlot {Head, Neck, Chest, Shoulder, Back, Belt, Legs, Feet, MainWeapon, OffHand}