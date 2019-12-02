using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    public int LevelToLoad;
    public bool doorOpen = true;
    public AudioClip openClip;

    private void Start()
    {
        LevelToLoad = SceneManager.GetActiveScene().buildIndex;

    }

    public void openingDoor() {
        if (!doorOpen) {
            SoundManager.instance.PlayClip(openClip, this.transform.position);
            doorOpen = true;
        }
    }

        public void closingDoor() {
        if (doorOpen) {
            doorOpen = false;
        }
    }

    private void saveGame()
    {
        GameSaver saver = new GameSaver() { level = LevelToLoad };
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + GameSaver.filename);
        bf.Serialize(file, saver);
        file.Close();
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (doorOpen)
        {

            if (collision.gameObject.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
                {
                    saveGame();
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
                    saveGame();
                    SceneManager.LoadScene(LevelToLoad);
                }
            }
        }
    }
}


