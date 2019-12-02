using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    internal enum Options { NEW = 0, LOAD = 1, QUIT = 2 }

    private Options selected = Options.NEW;
    GameSaver gameSaved = new GameSaver() { level = 1 };

    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/" + GameSaver.filename))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + GameSaver.filename, FileMode.Open);
            gameSaved = (GameSaver)bf.Deserialize(file);
            file.Close();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            switch(selected)
            {
                case Options.NEW:
                    selected = Options.LOAD;
                    break;
                case Options.LOAD:
                    selected = Options.QUIT;
                    break;
                case Options.QUIT:
                    selected = Options.NEW;
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            switch (selected)
            {
                case Options.NEW:
                    selected = Options.QUIT;
                    break;
                case Options.LOAD:
                    selected = Options.NEW;
                    break;
                case Options.QUIT:
                    selected = Options.LOAD;
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            switch (selected)
            {
                case Options.NEW:
                    newgame();
                    break;
                case Options.LOAD:
                    loadgame();
                    break;
                case Options.QUIT:
                    quit();
                    break;
            }
        }
    }

    public void newgame()
    {
        SceneManager.LoadScene(1);
    }

    public void loadgame()
    {
        SceneManager.LoadScene(gameSaved.level);
    }

    public void quit()
    {
        Application.Quit();
    }
}
