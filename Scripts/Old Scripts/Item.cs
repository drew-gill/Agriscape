using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item
{
    public int id;
    public string itemName;
    //public string description;
    public Sprite icon;
    public int buyValue;
    public int sellValue;
    //public int quality;
    public int expGiven;
    //public int quantity;

    public Item(int id, string itemName, int buyValue, int sellValue, int expGiven){
        this.id = id;
        this.itemName = itemName;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + itemName);
        this.buyValue = buyValue;
        this.sellValue = sellValue;
        //this.quantity = quantity;
        this.expGiven = expGiven;


    }

    public Item(Item item){
        this.id = item.id;
        this.itemName = item.itemName;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + item.itemName);
        this.buyValue = item.buyValue;
        this.sellValue = item.sellValue;
        //this.quantity = item.quantity;
        this.expGiven = item.expGiven;
    }


    public override string ToString()
    {
        return this.itemName;
    }

}
