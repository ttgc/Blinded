using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1Script : MonoBehaviour
{
    private simpleMovement player;

    private AudioSource scriptSource;
    public AudioClip voice_1;
    private bool voice_1_said = false;
    public AudioClip[] randomSounds;
    public AudioClip voice_2;
    private bool voice_2_said = false;
    public AudioClip voice_3;
    private bool voice_3_said = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<simpleMovement>();
    }

    // Update is called once per frame
    void Update()
    {       
        if (scriptSource != null && scriptSource.isPlaying)
        {
            if (randomSounds.Length != 0)
            {
                scriptSource = SoundManager.instance.PlayRandomClip(randomSounds, new Vector3(0, 0));
            }
        }
        else
        {
            player.disabled = false;
        }



        if (((3 < player.GetComponent<Transform>().position.x && player.GetComponent<Transform>().position.x < 4.5) || (-3.5< player.GetComponent<Transform>().position.x && player.GetComponent<Transform>().position.x < -2.5)) && voice_1_said && !voice_2_said)
        {
            player.disabled = true;
            player.footSteps.Pause();
            scriptSource = SoundManager.instance.PlayVoice(voice_2, new Vector3(0, 0));
            voice_2_said = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door") && !voice_1_said && !GameObject.FindObjectOfType<door>().doorOpen)
        {
            player.disabled = true;
            player.footSteps.Pause();
            scriptSource = SoundManager.instance.PlayVoice(voice_1, new Vector3(0, 0));
            voice_1_said = true;
        }

        if (collision.gameObject.CompareTag("Switch") && voice_1_said && !voice_3_said)
        {
            scriptSource = SoundManager.instance.PlayVoice(voice_3, new Vector3(0, 0));
            voice_3_said = true;
        }
    }
}
