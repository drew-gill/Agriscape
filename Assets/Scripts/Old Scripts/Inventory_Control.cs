using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Control : MonoBehaviour
{
    private bool inventoryEnabled;
    //private bool toolbarEnabled;
    private bool dialogueEnabled;

    public GameObject inventory;
    public GameObject dialogue;
    //public GameObject toolbar;


    // Start is called before the first frame update
    void Start()
    {
        inventoryEnabled = false;
        //toolbarEnabled = true;
        dialogueEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }

        if(inventoryEnabled == true)
        {
            inventory.SetActive(true);
            //toolbar.SetActive(false);
            dialogue.SetActive(false);
        }
        else
        {
            inventory.SetActive(false);
            //toolbar.SetActive(true);
            dialogue.SetActive(false);
        }

       
    }

    void UpdateUI()
    {
        Debug.Log("Updating UI");
    }
}
