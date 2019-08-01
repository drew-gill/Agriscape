using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Update : MonoBehaviour
{
    public Character Player;
    private ScoreKeeper scorekeeper;
    private string highScoreKey = "HighScore";
    private int highScore;

    [SerializeField]
    private Text Highscore;

    [SerializeField]
    private GameObject map;

    [SerializeField]
    private GameObject Title;


    public Text coinText;
    public Text healthText;
    public Text tomatoText;
    public Text carrotText;
    public Text potatoText;
    public Text cabbageText;
    public Text tomatoSeedText;
    public Text carrotSeedText;
    public Text potatoSeedText;
    public Text cabbageSeedText;
    public Text WeaponText;
    public Text DeathText;

    public GameObject WeaponSprite;
    public Sprite NoSprite;
    public Sprite ShovelSprite;
    public Sprite PickSprite;
    public Sprite AxeSprite;
    public Sprite ScytheSprite;


    // Start is called before the first frame update
    void Start()
    {
        scorekeeper = Player.GetComponent<ScoreKeeper>();

        //Get the highScore from player prefs if it is there, 0 otherwise.
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        Highscore.text = "Highscore: " + highScore;

    }

    // Update is called once per frame
    void Update()
    {
        if(Player.difficulty != Character.Difficulty.None)
        {
            Title.SetActive(false);
        }


        coinText.text = "Coins: " + scorekeeper.Coins;
        healthText.text = "Health: " + Player.Health;

        tomatoText.text = "Tomatoes: " + scorekeeper.Tomatoes;
        carrotText.text = "Carrots: " + scorekeeper.Carrots;
        potatoText.text = "Potatoes: " + scorekeeper.Potatoes;
        cabbageText.text = "Cabbages: " + scorekeeper.Cabbages;

        tomatoSeedText.text = "Seeds: " + scorekeeper.TomatoSeeds;
        carrotSeedText.text = "Seeds: " + scorekeeper.CarrotSeeds;
        potatoSeedText.text = "Seeds: " + scorekeeper.PotatoSeeds;
        cabbageSeedText.text = "Seeds: " + scorekeeper.CabbageSeeds;

        if(Player.Weapon == Character.WeaponType.None)
        {
            WeaponSprite.GetComponent<Image>().sprite = NoSprite;
            WeaponText.text = "Weapon: None (+0)";
        } else if (Player.Weapon == Character.WeaponType.Shovel)
        {
            WeaponSprite.GetComponent<Image>().sprite = ShovelSprite;
            WeaponText.text = "Weapon: Shovel (+3)";
        }
        else if (Player.Weapon == Character.WeaponType.Pick)
        {
            WeaponSprite.GetComponent<Image>().sprite = PickSprite;
            WeaponText.text = "Weapon: Pick (+5)";
        }
        else if (Player.Weapon == Character.WeaponType.Axe)
        {
            WeaponSprite.GetComponent<Image>().sprite = AxeSprite;
            WeaponText.text = "Weapon: Axe (+8)";
        }
        else if (Player.Weapon == Character.WeaponType.Scythe)
        {
            WeaponSprite.GetComponent<Image>().sprite = ScytheSprite;
            WeaponText.text = "Weapon: Scythe (+10)";
        }

        if(Player.Health <= 0)
        {
            DeathText.text = "You have died!" +
                "\n" +
                "\nIn the end, you managed to collect " + scorekeeper.Coins + " coins." +
                "\nYou were defeated by " + (Player.enemy.ToString().Equals("None") ? "Hunger" : ("a " + Player.enemy.ToString())) +
                "\nPress ESC to exit";

            GameObject.Find("Player").GetComponent<Player_Move_Force>().enabled = false; 
            map.SetActive(false);

            if (Input.GetKey("escape"))
            {
                Application.Quit();
            }
        }
    }

    
    public void ChangeSeeds(Dropdown change)
    {
        int option = change.value;

        if(option == 0)
        {
            if(scorekeeper.TomatoSeeds > 0)
            {
                Player.seeds = Character.PlantType.Tomato;
            }
        } else if (option == 1)
        {
            if (scorekeeper.CarrotSeeds > 0)
            {
                Player.seeds = Character.PlantType.Carrot;
            }
        } else if (option == 2)
        {
            if (scorekeeper.PotatoSeeds > 0)
            {
                Player.seeds = Character.PlantType.Potato;
            }
        } else if (option == 3)
        {
            if (scorekeeper.CabbageSeeds > 0)
            {
                Player.seeds = Character.PlantType.Cabbage;
            }
        }
    }

    private void OnDisable()
    {
        //If our scoree is greter than highscore, set new higscore and save.
        if (scorekeeper.Coins > highScore)
        {
            PlayerPrefs.SetInt(highScoreKey, scorekeeper.Coins);
            PlayerPrefs.Save();
        }
    }

}
