using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelection : MonoBehaviour
{
    public Character Player;
    public GameObject TitleUI;


    public void SetDifficulty(string Difficulty)
    {
        if(Difficulty == "Easy")
        {
            Player.difficulty = Character.Difficulty.Easy;
        }
        else if (Difficulty == "Medium")
        {
            Player.difficulty = Character.Difficulty.Medium;
        }
        else if (Difficulty == "Hard")
        {
            Player.difficulty = Character.Difficulty.Hard;
        }

        TitleUI.SetActive(false);
        
    }

}
