using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private void Awake(){
        BuildDatabase();

    }

    public Item GetItem(int id) {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string itemName){
        return items.Find(item => item.itemName == itemName);
    }

    public int GetBuyValue(int id)
    {
        Item temp = items.Find(item => item.id == id);
        return temp.buyValue;
    }

    public int GetBuyValue(string itemName)
    {
        Item temp = items.Find(item => item.itemName == itemName);
        return temp.buyValue;
    }

    public int GetSellValue(int id)
    {
        Item temp = items.Find(item => item.id == id);
        return temp.sellValue;
    }

    public int GetSellValue(string itemName)
    {
        Item temp = items.Find(item => item.itemName == itemName);
        return temp.sellValue;
    }

    public int GetEXPGiven(int id)
    {
        Item temp = items.Find(item => item.id == id);
        return temp.expGiven;
    }

    public int GetEXPGiven(string itemName)
    {
        Item temp = items.Find(item => item.itemName == itemName);
        return temp.expGiven;
    }

    void BuildDatabase(){
        items = new List<Item>() {
            new Item(0, "Tomato Seeds", 5, 1, 1),
            new Item(1, "Carrot Seeds", 7, 2, 1),
            new Item(2, "Potato Seeds", 9, 3, 1),
            new Item(3, "Cabbage Seeds", 11, 4, 1),
            new Item(10, "Tomato", 3, 7, 4),
            new Item(11, "Carrot", 4, 11,  5),
            new Item(12, "Potato", 5, 15, 6),
            new Item(13, "Cabbage", 6, 19, 7 )
            };
          
    }

}
