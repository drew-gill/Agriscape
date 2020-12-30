using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int coins;

    private int tomatoes;
    private int potatoes;
    private int cabbages;
    private int carrots;

    private int tomatoSeeds;
    private int potatoSeeds;
    private int cabbageSeeds;
    private int carrotSeeds;


    public int Coins { get { return coins; } set { coins = value; }  }
    public int Tomatoes { get { return tomatoes; } set { tomatoes = value; } }
    public int Potatoes { get { return potatoes; } set { potatoes = value; } }
    public int Cabbages { get { return cabbages; } set { cabbages = value; } }
    public int Carrots { get { return carrots; } set { carrots = value; } }
    public int TomatoSeeds { get { return tomatoSeeds; } set { tomatoSeeds = value; } }
    public int PotatoSeeds { get { return potatoSeeds; } set { potatoSeeds = value; } }
    public int CabbageSeeds { get { return cabbageSeeds; } set { cabbageSeeds = value; } }
    public int CarrotSeeds { get { return carrotSeeds; } set { carrotSeeds = value; } }

    // Start is called before the first frame update
    void Start()
    {
        Coins = 0;
        Tomatoes = 0;
        Potatoes = 0;
        Cabbages = 0;
        Carrots = 0;
        TomatoSeeds = 0;
        PotatoSeeds = 0;
        CabbageSeeds = 0;
        CarrotSeeds = 0;
    }

    public void Shop(Character.PlantType plant, bool buyShop)
    {
        if (buyShop)
        {
            if (plant == Character.PlantType.Tomato)
            {
                if (Coins >= 1)
                {

                    TomatoSeeds += 1;
                    Coins -= 1;
                }
            }
            else if (plant == Character.PlantType.Carrot)
            {
                if (Coins >= 2)
                {
                    CarrotSeeds += 1;
                    Coins -= 2;
                }
            }
            else if (plant == Character.PlantType.Potato)
            {
                if (Coins >= 3)
                {
                    PotatoSeeds += 1;
                    Coins -= 3;
                }
            }
            else if (plant == Character.PlantType.Cabbage)
            {
                if (Coins >= 4)
                {
                    CabbageSeeds += 1;
                    Coins -= 4;
                }
            }
        }
        else //use for selling
        {
            if (plant == Character.PlantType.Tomato)
            {
                if (Tomatoes > 0)
                {

                    Tomatoes -= 1;
                    Coins += 3;
                }
            }
            else if (plant == Character.PlantType.Carrot)
            {
                if (Carrots > 0)
                {
                    Carrots -= 1;
                    Coins += 6;
                }
            }
            else if (plant == Character.PlantType.Potato)
            {
                if (Potatoes > 0)
                {
                    Potatoes -= 1;
                    Coins += 9;
                }
            }
            else if (plant == Character.PlantType.Cabbage)
            {
                if (Cabbages > 0)
                {
                    Cabbages -= 1;
                    Coins += 12;
                }
            }
        }
    }

    //Upgrades previous weapon
    public bool ShopWeapon(Character.WeaponType newWeapon, Character.WeaponType currentWeapon)
    {
        if(newWeapon == Character.WeaponType.Shovel && Coins >= 25 && currentWeapon == Character.WeaponType.None)
        {
            Coins -= 25;
            return true;
        } else if (newWeapon == Character.WeaponType.Pick && Coins >= 50 && currentWeapon == Character.WeaponType.Shovel)
        {
            Coins -= 50;
            return true;
        } else if (newWeapon == Character.WeaponType.Axe && Coins >= 75 && currentWeapon == Character.WeaponType.Pick)
        {
            Coins -= 75;
            return true;
        } else if (newWeapon == Character.WeaponType.Scythe && Coins >= 99 && currentWeapon == Character.WeaponType.Axe)
        {
            Coins -= 99;
            return true;
        }
        else
        {
            return false;
        }

    }

    public void Gift()
    {
        Character.Difficulty difficulty = GameObject.Find("PlayerInfo").GetComponent<Character>().difficulty;
        if(difficulty == Character.Difficulty.Easy)
        {
            TomatoSeeds += 5;
        } else if (difficulty == Character.Difficulty.Medium)
        {
            TomatoSeeds += 3;
        } else if (difficulty == Character.Difficulty.Hard)
        {
            TomatoSeeds += 1;
        }
    }

    public void HarvestCrops(Character.PlantType plant)
    {

        if(plant == Character.PlantType.Carrot)
        {
            Carrots += 1;
        } else if (plant == Character.PlantType.Tomato)
        {
            Tomatoes += 1;
        } else if (plant == Character.PlantType.Potato)
        {
            Potatoes += 1;
        } else if (plant == Character.PlantType.Cabbage)
        {
            Cabbages += 1;
        }
        

    }


}
