﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public string description;
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        //use item
        //something happens?

        Debug.Log("Using "+name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
