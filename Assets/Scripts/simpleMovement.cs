using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class simpleMovement : MonoBehaviour
{
    private float jumpForce = 5f;
    public bool isJumping = false;

    public AudioClip[] audioClips;
    public AudioClip hurtClip;
    public AudioClip deathClip;
    public AudioClip fenceClip;
    public AudioClip jumpSound;
    private Rigidbody2D rb;
    public float speed = 1.0f;
    public AudioSource footSteps;
    bool steps = false;

    public bool disabled = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!disabled)
        {
            float move = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(move * speed, rb.velocity.y);

            if ((rb.velocity.x != 0) && !isJumping)
                steps = true;
            else
                steps = false;

            if (steps)
            {
                if (!footSteps.isPlaying)
                    footSteps.Play();
            }
            else
            {
                footSteps.Pause();
                footSteps.Stop();
            }
            footSteps.panStereo = SoundManager.instance.ConvertPosToPan(this.transform.position);

            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (!isJumping)
                {
                    rb.AddForce(jumpForce * Vector3.up, ForceMode2D.Impulse);
                    SoundManager.instance.PlayClip(jumpSound, this.transform.position);

                }

            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            SoundManager.instance.PlayRandomClip(audioClips, this.transform.position);
            if (disabled) rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (col.gameObject.CompareTag("Pikes"))
        {
            SoundManager.instance.PlayClip(deathClip, this.transform.position);
            die();
        }
        if (col.gameObject.CompareTag("Bullet"))
        {
            SoundManager.instance.PlayClip(deathClip, this.transform.position);
            die();
        }

        if (col.gameObject.CompareTag("Fence"))
        {
            SoundManager.instance.PlayClip(fenceClip, this.transform.position);
        }

        if (col.gameObject.CompareTag("Wall"))
        {
            var normal = col.contacts[0].normal;
            if (normal.y > 0)
            { //if the bottom side hit something 
            SoundManager.instance.PlayRandomClip(audioClips, this.transform.position);
            }
            if (normal.x != 0)
            {
                SoundManager.instance.PlayClip(hurtClip, this.transform.position);

            }
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Pikes"))
        {
            SoundManager.instance.PlayClip(deathClip, this.transform.position);
            die();
        }

        if (col.gameObject.CompareTag("Pendulum"))
        {
            SoundManager.instance.PlayClip(deathClip, this.transform.position);
            die();
        }
        if (col.gameObject.CompareTag("Bullet"))
        {
            SoundManager.instance.PlayClip(deathClip, this.transform.position);
            die();
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && disabled)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

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
