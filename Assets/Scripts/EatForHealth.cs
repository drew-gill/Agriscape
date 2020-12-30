using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatForHealth : MonoBehaviour
{
    [SerializeField]
    private Character Player;

    [SerializeField]
    private Character.PlantType plant; 

    private ScoreKeeper scoreKeeper;

    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = Player.GetComponent<ScoreKeeper>();
        
    }

    public void Eat()
    {
        if(plant == Character.PlantType.Tomato && scoreKeeper.Tomatoes > 0)
        {
            scoreKeeper.Tomatoes -= 1;
            Player.Health += 20;
            if(Player.Health > 100)
            {
                Player.Health = 100;
            }
        } else if (plant == Character.PlantType.Carrot && scoreKeeper.Carrots > 0)
        {
            scoreKeeper.Carrots -= 1;
            Player.Health += 35;
            if (Player.Health > 100)
            {
                Player.Health = 100;
            }
        } else if (plant == Character.PlantType.Potato && scoreKeeper.Potatoes > 0)
        {
            scoreKeeper.Potatoes -= 1;
            Player.Health += 50;
            if (Player.Health > 100)
            {
                Player.Health = 100;
            }
        } else if (plant == Character.PlantType.Cabbage && scoreKeeper.Cabbages > 0)
        {
            scoreKeeper.Cabbages -= 1;
            Player.Health += 65;
            if (Player.Health > 100)
            {
                Player.Health = 100;
            }
        }
    }


}
