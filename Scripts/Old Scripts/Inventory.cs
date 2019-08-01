using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase;
    public UIInventory inventoryUI;

    private void Start()
    {
        //GiveItem(0);
        //GiveItem(1);
        //GiveItem(2);
        //GiveItem(3);
        //GiveItem(10);
        //GiveItem(11); 
        //GiveItem(12); 
        //GiveItem(13);

        //RemoveItem(1);
    }

    private void Update()
    {

    }

    public void GiveItem(int id){
        Item itemToAdd = itemDatabase.GetItem(id);
        characterItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
        Debug.Log("Added item: " + itemToAdd.itemName);
    }

    public void GiveItem(string itemName)
    {
        Item itemToAdd = itemDatabase.GetItem(itemName);
        Debug.Log(itemToAdd);
        characterItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
        Debug.Log("Added item: " + itemToAdd.itemName);
    }

    public Item CheckForItem(int id)
    {
        return characterItems.Find(item => item.id == id);
    }

    public void RemoveItem(int id)
    {
        Item item = CheckForItem(id);
        if (item != null)
        {
            characterItems.Remove(item);
            inventoryUI.RemoveItem(item);
            Debug.Log("Item Removed: " + item.itemName);

        }
    }

}

