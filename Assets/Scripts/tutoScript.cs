using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutoScript : MonoBehaviour
{
    static private bool hasReload = false;
    private simpleMovement player;
    private bool hasFinished = false;
    private bool hasFallen = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<simpleMovement>();

        if (!hasReload)
        {
            //intro
        }
        else
        {
            //reload
            GameObject.FindObjectOfType<door>().openingDoor();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) hasReload = true;

        if (player.GetComponent<Transform>().position.y < -6 && !hasFallen)
        {
            if (!hasReload)
            {
                //learn retry
            }
            else
            {
                //re learn retry
            }

            hasFallen = true;
        }

        if (player.GetComponent<Transform>().position.x > 1 && hasReload && !hasFinished)
        {
            //congratulations

            hasFinished = true;
        }
    }
}
