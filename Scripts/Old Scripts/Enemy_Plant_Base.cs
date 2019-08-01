using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy_Plant_Base : MonoBehaviour
{
    public Sprite seed_SP;
    public Sprite growing_SP;
    public Sprite grown_SP;
    public Sprite monster_SP;

    public float growth_time;

    public int health;
    public int attack;
    public int defense;

    public int XP_drop;
    public GameObject drop;


}
