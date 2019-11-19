using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundSwitch : MonoBehaviour
{
    public door DoorToOpen;
    public AudioClip on;
    public AudioClip off;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.instance.PlayClip(on, this.transform.position);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
       // if (collision.gameObject.CompareTag("Box"))
       // {
            DoorToOpen.openingDoor();
       // }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       // if (collision.gameObject.CompareTag("Box"))
       // {
            DoorToOpen.closingDoor();
            SoundManager.instance.PlayClip(off, this.transform.position);
       // }
    }
}
