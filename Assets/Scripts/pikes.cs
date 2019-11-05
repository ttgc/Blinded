using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pikes : MonoBehaviour
{
    public bool isMoving;
    public float loop = 4F;
    public AudioClip upClip;
    public AudioClip downClip;
    // Start is called before the first frame update
    void Start()
    {
        if (isMoving) {
            InvokeRepeating("Down", 1F, loop);
            InvokeRepeating("Up", 1F + loop/2, loop);
        }
    }

    void Up() {
        transform.Translate(new Vector3(0, 0.35F, 0));
        SoundManager.instance.PlayClip(upClip, this.transform.position);
    }

    void Down() {
        transform.Translate(new Vector3(0, -0.35F, 0));
        SoundManager.instance.PlayClip(downClip, this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
