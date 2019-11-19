using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingWall : MonoBehaviour
{
    
    public float loop = 8F;
    public AudioClip upClip;
    public AudioClip downClip;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Down", 1F, loop);
        InvokeRepeating("Up", 1F + loop/2, loop);
    }

    void Up() {
        transform.Translate(new Vector3(0, 1.5F, 0));
        SoundManager.instance.PlayClip(upClip, this.transform.position);
    }

    void Down() {
        transform.Translate(new Vector3(0, -1.5F, 0));
        SoundManager.instance.PlayClip(downClip, this.transform.position);
    }
}
