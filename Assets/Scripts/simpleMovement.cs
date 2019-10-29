using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleMovement : MonoBehaviour
{
    private float jumpForce = 5f;
    public AudioClip[] audioClips;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {}

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(jumpForce * Vector3.up, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Ground")) {
            SoundManager.instance.PlayRandomClip(audioClips);
        }
    }
}
