using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FarmPlot : MonoBehaviour
{
    [SerializeField]
    private GameObject Tomato;

    [SerializeField]
    private GameObject Carrot;

    [SerializeField]
    private GameObject Potato;

    [SerializeField]
    private GameObject Cabbage;


    public Character Player;




    private ScoreKeeper scoreKeeper;
    private Character.PlantType seeds;
    private bool plantGrowing;
    public bool PlantGrowing
    {
        get
        {
            return plantGrowing;
        }
        set
        {
            plantGrowing = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlantGrowing = false;
        seeds = Player.seeds;
        scoreKeeper = Player.GetComponent<ScoreKeeper>();
        
    }

    // Update is called once per frame
    void Update()
    {
        seeds = Player.seeds;
    }

    public void OnMouseDown()
    {

        if (!PlantGrowing && (seeds != Character.PlantType.None))
        {
            if (seeds == Character.PlantType.Tomato && (scoreKeeper.TomatoSeeds > 0))
            {
                Instantiate(Tomato, this.transform);
                PlantGrowing = true;
                this.transform.GetComponent<BoxCollider2D>().enabled = false;
                scoreKeeper.TomatoSeeds -= 1;
            }
            else if (seeds == Character.PlantType.Carrot && (scoreKeeper.CarrotSeeds > 0))
            {
                Instantiate(Carrot, this.transform);
                PlantGrowing = true;
                this.transform.GetComponent<BoxCollider2D>().enabled = false;
                scoreKeeper.CarrotSeeds -= 1;
            }
            else if (seeds == Character.PlantType.Cabbage && (scoreKeeper.CabbageSeeds > 0))
            {
                Instantiate(Cabbage, this.transform);
                PlantGrowing = true;
                this.transform.GetComponent<BoxCollider2D>().enabled = false;
                scoreKeeper.CabbageSeeds -= 1;
            }
            else if (seeds == Character.PlantType.Potato && (scoreKeeper.PotatoSeeds > 0))
            {
                Instantiate(Potato, this.transform);
                PlantGrowing = true;
                this.transform.GetComponent<BoxCollider2D>().enabled = false;
                scoreKeeper.PotatoSeeds -= 1;
            }




        }
    }

    public void PlantSeed()
    {
       


    }

}
