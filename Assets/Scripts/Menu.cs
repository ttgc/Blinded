using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    internal enum Options { NEW = 0, LOAD = 1, QUIT = 2 }

    private Options selected = Options.NEW;

    // Start is called before the first frame update
    void Start()
    {
        
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

    }

    public void loadgame()
    {

    }

    public void quit()
    {
        Application.Quit();
    }
}
