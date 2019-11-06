using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switches : MonoBehaviour
{
    public door DoorToOpen;
    public AudioClip actionClip;

    void Start()
    {}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DoorToOpen.openingDoor();
            SoundManager.instance.PlayClip(actionClip, this.transform.position);
        }
        
    }
}
    