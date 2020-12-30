using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Object.DontDestroyOnLoad example.
//
// This script example manages the playing audio. The GameObject with the
// "Player" tag is the Player GameObject. This will allow data to transfer
// from normal scene to battle scene.

public class DontDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject Level;

    void Awake()
    {
        DestroyExtras("PlayerInfo");
        DestroyExtras("Level");
        

        DontDestroyOnLoad(this.gameObject);
    }

    private void DestroyExtras(string tag)
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
    }


    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Scene2_Battle")
        {
            Level.SetActive(false);
        }
        else
        {
            Level.SetActive(true);
        }
    }


}