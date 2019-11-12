using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutoScript : MonoBehaviour
{
    static private bool hasReload = false;
    private simpleMovement player;
    private bool hasFinished = false;
    private bool hasFallen = false;
    private int stepIntro = 0;

    public AudioClip ambiant;
    public AudioClip intro_1;
    public AudioClip[] randomSounds;
    public AudioClip intro_2;
    public AudioClip fall;
    public AudioClip fallAgain;
    public AudioClip congrats;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<simpleMovement>();
        SoundManager.instance.musicSource.loop = true;
        SoundManager.instance.musicSource.PlayOneShot(ambiant);

        if (!hasReload)
        {
            SoundManager.instance.PlayClip(intro_1, new Vector3(0, 0));
            stepIntro++;
        }
        else
        {
            //reload
            GameObject.FindObjectOfType<door>().openingDoor();
            player.disabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) hasReload = true;

        if (stepIntro == 1 && !SoundManager.instance.efxSource.isPlaying)
        {
            SoundManager.instance.PlayRandomClip(randomSounds, new Vector3(0, 0));
            stepIntro++;
        }
        if (stepIntro == 2 && !SoundManager.instance.efxSource.isPlaying)
        {
            SoundManager.instance.PlayClip(intro_2, new Vector3(0, 0));
            stepIntro++;
        }
        if (stepIntro == 3 && !SoundManager.instance.efxSource.isPlaying)
        {
            player.disabled = false;
            stepIntro++;
        }

        if (player.GetComponent<Transform>().position.y < -6 && !hasFallen)
        {
            player.disabled = true;
            if (!hasReload)
            {
                //learn retry
            }
            else
            {
                //re learn retry
            }

            hasFallen = true;
            player.disabled = false;
        }

        if (player.GetComponent<Transform>().position.x > 1 && hasReload && !hasFinished)
        {
            player.disabled = true;
            //congratulations

            hasFinished = true;
            player.disabled = false;
        }
    }
}
