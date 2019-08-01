using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private bool WeaponShop;

    [SerializeField]
    private bool buyShop;

    [SerializeField]
    private bool Gift;

    [SerializeField]
    private GameObject gift;

    [SerializeField]
    private Character.PlantType plantType;

    [SerializeField]
    private Character.WeaponType weapon;

    private ScoreKeeper scorekeeper;
    private Character player;

    private void Start()
    {
        player = GameObject.Find("PlayerInfo").GetComponent<Character>();
        scorekeeper = GameObject.Find("PlayerInfo").GetComponent<ScoreKeeper>();
        
    }

    public void OnMouseDown()
    {
        if (WeaponShop)
        {
            bool bought = scorekeeper.ShopWeapon(weapon, player.Weapon);
            if (bought)
            {
                player.Weapon = weapon;
                this.gameObject.SetActive(false);
            }
        }   else if (Gift)
        {
            scorekeeper.Gift();
            Destroy(gift);
        }
        else
        {
            //If buyshop, will buy crop seeds
            //If not buyshop, will sell crop
            scorekeeper.Shop(plantType, buyShop);

        }

    }
}
