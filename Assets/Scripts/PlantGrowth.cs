using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlantGrowth : MonoBehaviour
{


    [SerializeField]
    private Sprite SeedSprite;

    [SerializeField]
    private Sprite GrowingSprite;

    [SerializeField]
    private Sprite GrownSprite;

    [SerializeField]
    private Sprite VegetableSprite;

    [SerializeField]
    private Sprite MonsterSprite;

    [SerializeField]
    private float GrowthTime;

    [SerializeField]
    private Character.PlantType plantType;

    [SerializeField]
    private Character player;


    private Sprite currentGrowthStage;
    private bool isHarvested;
    private float startTime;
    private float timeSinceStart;
    Random random = new Random();

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        currentGrowthStage = SeedSprite;
        this.GetComponent<SpriteRenderer>().sprite = currentGrowthStage;
        player = GameObject.Find("PlayerInfo").transform.GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceStart = Time.time - startTime;

        if(plantType != Character.PlantType.None)
        {
            if (!isHarvested)
            {
                if (timeSinceStart < (GrowthTime / 4))
                {
                    ChangeGrowthStage(SeedSprite);
                }
                else if (timeSinceStart < GrowthTime)
                {
                    ChangeGrowthStage(GrowingSprite);
                }
                else
                {
                    ChangeGrowthStage(GrownSprite);
                }
            }

        }

    }



    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            if(this.currentGrowthStage.Equals(VegetableSprite))
            {
                GameObject.Find("PlayerInfo").GetComponent<ScoreKeeper>().HarvestCrops(plantType);
                this.transform.parent.GetComponent<BoxCollider2D>().enabled = true;
                this.transform.parent.GetComponent<FarmPlot>().PlantGrowing = false;
                Destroy(this.gameObject);
            } else if (this.currentGrowthStage.Equals(MonsterSprite))
            {
                this.transform.parent.gameObject.GetComponent<FarmPlot>().Player.enemy = this.plantType;
                SceneManager.LoadScene("Scene2_Battle");
                ChangeGrowthStage(VegetableSprite);
            }
        }

    }


    //if ready to harvest, turns into monster on click (on collider)
    private void OnMouseDown()
    {
        if (currentGrowthStage.Equals(GrownSprite))
        {
            int chance = 7;
            if (player.difficulty == Character.Difficulty.Easy)
            {
                chance = 7;
            } else if (player.difficulty == Character.Difficulty.Medium)
            {
                chance = 6;
            } else if (player.difficulty == Character.Difficulty.Hard)
            {
                chance = 5;
            }

            int random = Random.Range(0, 11);
            isHarvested = true;
            if (random >= chance)
            {
                ChangeGrowthStage(MonsterSprite);
            }
            else
            {
                ChangeGrowthStage(VegetableSprite);
            }

        }
    }

    private void ChangeGrowthStage(Sprite newStage)
    {
        currentGrowthStage = newStage;
        this.GetComponent<SpriteRenderer>().sprite = currentGrowthStage;
    }
}
