using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerClickHandler
{
    public Item item;
    private Image spriteImage;
    private UIItem selectedItem;

    private void Awake(){
        spriteImage = GetComponent<Image>();
        //UpdateItem(null);
        selectedItem = GameObject.Find("Selected Item").GetComponent<UIItem>();

    }

    public void UpdateItem(Item item) {
        this.item = item;

        if(this.item != null){
            spriteImage.color = Color.white;
            spriteImage.sprite = this.item.icon;
            Debug.Log("Sprite Was Changed");
        } else {
            spriteImage.color = Color.clear;
            Debug.Log("Sprite Wasn't Changed");

        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (this.item != null)
        {
            if (selectedItem.item != null)
            {
                Item clone = new Item(selectedItem.item);
                selectedItem.UpdateItem(this.item);
                UpdateItem(clone);
            }
            else
            {
                selectedItem.UpdateItem(this.item);
                UpdateItem(null);
            }
        } else if (selectedItem.item != null)
        {
            UpdateItem(selectedItem.item);
            selectedItem.UpdateItem(null);
        }

        //throw new System.NotImplementedException();
    }
}
