using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPickup : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();

        //pickup item
        Pickup();
    }

    void Pickup()
    {
        Debug.Log("Picked up " + item.name);
        //add to inventory
        bool pickedUp = Inventory.instance.Add(item);
        //destroy from scene
        if(pickedUp)
        {
            Destroy(gameObject);
        }
        
    }

    public void OnMouseOver()
    {
        TooltipSystem.ShowTooltip(item.description, item.name);
    }

    public void OnMouseExit()
    {
        TooltipSystem.HideTooltip();
    }
}
