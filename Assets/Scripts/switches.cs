using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switches : MonoBehaviour
{
    public door DoorToOpen;

    void Start()
    {}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DoorToOpen.doorOpen = true;
        }
        
    }
}
    