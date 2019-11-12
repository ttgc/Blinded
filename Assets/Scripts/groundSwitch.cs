using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundSwitch : MonoBehaviour
{
    public door DoorToOpen;
    public AudioClip actionClip;

    void Start()
    { }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            DoorToOpen.openingDoor();
            //SoundManager.instance.PlayClip(actionClip, this.transform.position);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            DoorToOpen.closingDoor();
            //SoundManager.instance.PlayClip(actionClip, this.transform.position);
        }
    }
}
