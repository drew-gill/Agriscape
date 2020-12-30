using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health_Segmented : MonoBehaviour {
    // InstaDeath objects should be tagged "Death" and set as a trigger
    // Enemies (and other 1-damage obstacles) should be tagged "Enemy" and should NOT be set as a trigger

    private GameObject respawn;

    private int playerMoney;
    private int playerHealth;
    private int playerEnergy;

    private GameObject[] items;
    private int[] num_items;
    private int iterate;


   

    [Tooltip("The score value of a coin or pickup.")]
    public int coinValue = 5;
   //[Tooltip("The amount of points a player loses on death.")]
    //public int deathPenalty = 20;

    public Text moneyText;
    // Feel free to add more! You'll need to edit the script in a few spots, though.
    public GameObject health3;
    public GameObject health2;
    public GameObject health1;







    // Use this for initialization
    void Start()
    {
        playerMoney = 500;
        moneyText.text = playerMoney.ToString();
       

    }



    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        int counter = 0;

        if ((collision != null) && collision.collider.CompareTag("Stuff"))
        {
            counter++;

        }

        Debug.Log(counter + " Stuff Was Collected");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    */
    /*private void TakeDamage()
    {
        // For more health, copy the if block for health3, change health3 to whatever yours is,
        // then change the if statement for health3 to else if
        if (health3.activeInHierarchy)
        {
            health3.SetActive(false);
        }
        else if (health2.activeInHierarchy)
        {
            health2.SetActive(false);
        }
        else
        {
            health1.SetActive(false);
            Respawn();
        }
    }
     
    private void AddHealth()
    {
        if (!health2.activeInHierarchy)
        {
            health2.SetActive(true);
        }
        else if (!health3.activeInHierarchy)
        {
            health3.SetActive(true);
        }
        // For more health, just copy the else if block for health3 and change the name.
    }

    public void Respawn()
    {
        // For more health, just add another similar line here.
        health3.SetActive(true);
        health2.SetActive(true);
        health1.SetActive(true);
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.transform.position = respawn.transform.position;
        AddPoints(deathPenalty);
    }
    */
    public int GetMoney()
    {
        return playerMoney;
    }

    public void TypeInventory()
    {
        //
    }

    public void AddMoney(int amount)
    {
        playerMoney += amount;
        moneyText.text = playerMoney.ToString("D4");
    }
}
