using UnityEngine;
using UnityEngine.SceneManagement;

// Object.DontDestroyOnLoad example.
//
// Two scenes call each other. This happens when OnGUI button is clicked.
// scene1 will load scene2; scene2 will load scene1. Both scenes have
// the Menu GameObject with the SceneSwap.cs script attached.


public class SceneSwap : MonoBehaviour
{
    public void SwapScene()
    {

        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Scene1_Madison")
        {

            SceneManager.LoadScene("Scene2_Battle");
        }
        else
        {
            GameObject.Find("PlayerInfo").GetComponent<Character>().Health -= 50;
              SceneManager.LoadScene("Scene1_Madison");
        }
    }
}