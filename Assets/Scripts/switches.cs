using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switches : MonoBehaviour
{
    public door DoorToOpen;

    void Start()
    {
        GameObject g = GameObject.FindGameObjectWithTag("Door");
        //assigns the script component "IGotBools" to the public variable of type "IGotBools" names boolBoy.
        DoorToOpen = g.GetComponent<door>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DoorToOpen.doorOpen = true;
        }
        
    }
}
    