using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    public int LevelToLoad;
    public bool doorOpen = true;


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


