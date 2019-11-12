using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class simpleMovement : MonoBehaviour
{
    private float jumpForce = 5f;
    public bool isJumping = false;

    public AudioClip[] audioClips;
    public AudioClip deathClip;
    private Rigidbody2D rb;
    public float speed = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if ((Input.GetAxis("Horizontal") != 0) || !isJumping)
        {
            //ajout du son de marche
        }
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!isJumping)
            {
                rb.AddForce(jumpForce * Vector3.up, ForceMode2D.Impulse);
                //rb.velocity = new Vector2(rb.velocity.x, jumpForce); marche aussi
                //isJumping = true;
                //ajout du son de saut
            }

        }
    }

    void die() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Ground")) {
            //isJumping = false;
            SoundManager.instance.PlayRandomClip(audioClips, this.transform.position);
        }

        if (col.gameObject.CompareTag("Pikes")) {
            SoundManager.instance.PlayClip(deathClip, this.transform.position);
            die();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Pikes")) {
            SoundManager.instance.PlayClip(deathClip, this.transform.position);
            die();
        }
    }

   
    private void OnCollisionStay2D(Collision2D collision)
    {
        var normal = collision.contacts[0].normal;
        if (normal.y > 0)
        { //if the bottom side hit something 
            isJumping = false;
        }
        
    }
    private void OnCollisionExit2D()
    {
        isJumping = true;
    }

    
}
