using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> uIItems = new List<UIItem>();
    public GameObject slotPrefab;
    public Transform slotPanel;
    public int numberOfSlots = 25;

    private void Awake(){
        for( int i = 0; i < numberOfSlots; i++){
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            uIItems.Add(instance.GetComponentInChildren<UIItem>());

        }

    }

    public void UpdateSlot(int slot, Item item){
        UIItem temp = uIItems[slot];
        temp.UpdateItem(item);

    }

    public void AddNewItem(Item item){
        //UpdateSlot(0, item);
       UpdateSlot(uIItems.FindIndex(i => i.item == null), item);
    }

    public void RemoveItem(Item item) { 
       UpdateSlot(uIItems.FindIndex(i => i.item == item), null);

    }





}
