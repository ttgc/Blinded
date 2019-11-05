using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    public int LevelToLoad;
    public bool doorOpen = true;
    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;
        if (sceneName == "SoundManagerSample") // Si le niveau contient des interrupteurs, on le met ici
        {
            doorOpen = false;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (doorOpen)
        {

            if (collision.gameObject.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene(LevelToLoad);

                }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (doorOpen)
        {

            if (collision.gameObject.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
                {
                    //SceneManager.LoadScene(LevelToLoad);
                    SceneManager.LoadScene("SoundManagerSample");

                }
            }
        }
    }
}


