using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Battle : MonoBehaviour
{
    private Character player;


    private Character.PlantType enemyInfo;
    private Character enemy;
    private int playerHealth;
    private bool playersTurn;
    private GameObject battleInfo;
    private GameObject battleMenu;
    private GameObject turnText;
    private GameObject stats;
    private Character winner;

    // Start is called before the first frame update
    void Start()
    {
        player = this.transform.Find("/PlayerInfo").GetComponent<Character>();

        //battleMenu.setActive(false);
        playersTurn = false;
        battleInfo = this.transform.Find("BattleInfo").gameObject;
        battleMenu = this.transform.Find("BattleMenu").gameObject;

        turnText = battleInfo.transform.Find("Turn").gameObject;
        stats = battleInfo.transform.Find("Stats").gameObject;

        player.transform.position = new Vector3(-8f, -1.5f, 0);
        enemyInfo = player.enemy;
        SetSprites();
    }

    private void SetSprites()
    {
        GameObject enemyGameObject;

        if (enemyInfo == Character.PlantType.Tomato)
        {
            enemyGameObject = this.transform.Find("Enemies/Tomato").gameObject;
        } else if (enemyInfo == Character.PlantType.Carrot)
        {
            enemyGameObject = this.transform.Find("Enemies/Carrot").gameObject;
        }
        else if (enemyInfo == Character.PlantType.Cabbage)
        {
            enemyGameObject = this.transform.Find("Enemies/Cabbage").gameObject;
        }
        else
        {
            enemyGameObject = this.transform.Find("Enemies/Potato").gameObject;
        }
        enemyGameObject.SetActive(true);
        enemy = enemyGameObject.transform.GetComponent<Character>();
        enemy.SpecialAttack = 0;

        //this.transform.Find("PlayerSprite").GetComponent<SpriteRenderer>().sprite = player.icon;
        //this.transform.Find("PlayerSprite").gameObject.SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {
        if(winner != null)
        {
            if (winner.Equals(player))
            {
                battleInfo.transform.Find("WinLoss/Win").gameObject.SetActive(true);
                player.enemy = Character.PlantType.None;
                SceneManager.LoadScene("Scene1_Madison");

            }
            else
            {
                battleInfo.transform.Find("WinLoss/Lose").gameObject.SetActive(true);
                SceneManager.LoadScene("Scene1_Madison");
            }
        }
        else
        {
            TurnChange();

        }




        stats.transform.Find("PlayerStats").gameObject.GetComponent<Text>().text =
            "Player: " + player.name +
            "\nHEALTH: " + player.Health +
            "\nSTRENGTH: " + player.Strength +
            "\nWEAPON: " + player.Weapon +
            "\nSPECIAL ATTACK: " + player.SpecialAttack + "%";


        stats.transform.Find("EnemyStats").gameObject.GetComponent<Text>().text =
            "ENEMY: " + enemy.name + 
            "\nHEALTH: " + enemy.Health +
            "\nSTRENGTH: " + enemy.Strength +
            "\nWEAPON: " + enemy.Weapon +
            "\nSPECIAL ATTACK: " + enemy.SpecialAttack + "%";
        



    }

    public void PlayerAttack()
    {
        if (playersTurn)
        {
            DetermineAttack(player, enemy);
        }
    }




    public void Attack (Character attacker, Character victim)
    {
        victim.Health -= attacker.Strength;
        attacker.SpecialAttack += 20;
        if (victim.Health <= 0)
        {
            winner = attacker;
        }
        playersTurn = !playersTurn;


    }

    public void SpecialAttack(Character attacker, Character victim)
    {
        attacker.Strength *= 2;
        Attack(attacker, victim);
        attacker.Strength /= 2;
        attacker.SpecialAttack -= 100;
    }

    private void DetermineAttack(Character attacker, Character victim)
    {
        if (attacker.SpecialAttack >= 100)
        {
            SpecialAttack(attacker, victim);
        }
        else
        {

            Attack(attacker, victim);
        }
    }

    private void TurnChange()
    {
        if (playersTurn)
        {
            battleMenu.SetActive(true);
            turnText.transform.Find("PlayerTurn").gameObject.SetActive(true);
            turnText.transform.Find("EnemyTurn").gameObject.SetActive(false);

        }
        else
        {
            battleMenu.SetActive(false);
            turnText.transform.Find("PlayerTurn").gameObject.SetActive(false);
            turnText.transform.Find("EnemyTurn").gameObject.SetActive(true);

            DetermineAttack(enemy, player);
        }
    }


}
