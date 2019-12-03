using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public AudioClip[] audioClips;
    public float speed = 10F;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        SoundManager.instance.PlayRandomClip(audioClips, this.transform.position);
        Destroy(gameObject);
    }

}
