using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //This allows us to access our inventory from anywhere with Inventory.instance
    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    #endregion
    
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public int invSpace = 25;
    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if(!item.isDefaultItem)
        {
            if(items.Count >= invSpace)
            {
                Debug.Log("Not enough inventory space!");
                return false;
            }
            items.Add(item);
            //call the delegate to update gamestate
            if(onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
            
        }
        return true;
    }

    public void Remove (Item item)
    {
        items.Remove(item);

        //call the delegate to update gamestate
        if(onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
