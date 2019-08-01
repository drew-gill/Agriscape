using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{


    public Sprite icon;
    public int Health;
    public int baseStrength;
    public int Strength;
    public int SpecialAttack;


    public enum PlantType
    {
        None,
        Tomato,
        Carrot,
        Potato,
        Cabbage,
    };

    //Weapons, in increasing order of strength
    public enum WeaponType
    {
        None,
        Shovel,
        Pick,
        Axe,
        Scythe,
    };

    public enum Difficulty
    {
        None,
        Easy,
        Medium,
        Hard
    };

    public PlantType enemy;
    public PlantType seeds;
    public WeaponType Weapon;
    public Difficulty difficulty;


    //Over time, the player loses health
    private void Start()
    {
        InvokeRepeating("Decay", 1.0f, 10.0f);



    }

    private void Decay()
    {
        int decayMultiplier = 1;

        if (difficulty == Character.Difficulty.Easy)
        {
            decayMultiplier = 1;
        }
        else if (difficulty == Character.Difficulty.Medium)
        {
            decayMultiplier = 2;
        }
        else if (difficulty == Character.Difficulty.Hard)
        {
            decayMultiplier = 3;
        }

        //Prevents decay during fight scenes
        if(enemy != Character.PlantType.None)
        {
            Health += (1*decayMultiplier);
        }

        //Prevents decay for enemies
        if(seeds == Character.PlantType.None)
        {
            Health += (1 * decayMultiplier);
        }

        Health -= (1 * decayMultiplier);


    }

    private void Update()
    {
        if(Weapon == WeaponType.None)
        {
            Strength = baseStrength + 0;
        } else if (Weapon == WeaponType.Shovel)
        {
            Strength = baseStrength + 3;
        }
        else if (Weapon == WeaponType.Pick)
        {
            Strength = baseStrength + 5;
        }
        else if (Weapon == WeaponType.Axe)
        {
            Strength = baseStrength + 8;
        }
        else if (Weapon == WeaponType.Scythe)
        {
            Strength = baseStrength + 10;
        }
    }




}
