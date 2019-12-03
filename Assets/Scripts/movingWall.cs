using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingWall : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip upClip;
    public AudioClip downClip;
    private float interval = 3.2f;
    private int direction;
    private float speed = 0.03f;
    void Start()
    {
        InvokeRepeating("Down", 5F, interval * 4);
        InvokeRepeating("Pause", 5F + interval, interval * 2);
        InvokeRepeating("Up", 5F + interval * 2, interval * 4);
        direction = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.up * direction * speed;
    }

    void Up()
    {
        SoundManager.instance.PlayClip(upClip, this.transform.position);
        direction = 1;
    }
    void Down()
    {
        SoundManager.instance.PlayClip(downClip, this.transform.position);
        direction = -1;
    }
    void Pause()
    {
        direction = 0;
    }
}
