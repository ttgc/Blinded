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
    private bool isFalling = false;
    private bool isCongrats = false;
    private AudioSource scriptSource;

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

        if (!hasReload)
        {
            scriptSource = SoundManager.instance.PlayVoice(intro_1, new Vector3(0, 0));
            stepIntro++;
        }
        else
        {
            GameObject.FindObjectOfType<door>().openingDoor();
            player.disabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !player.disabled) hasReload = true;

        if (stepIntro == 1 && !scriptSource.isPlaying)
        {
            scriptSource = SoundManager.instance.PlayRandomClip(randomSounds, new Vector3(0, 0));
            stepIntro++;
        }
        if (stepIntro == 2 && !scriptSource.isPlaying)
        {
            scriptSource = SoundManager.instance.PlayVoice(intro_2, new Vector3(0, 0));
            stepIntro++;
        }
        if (stepIntro == 3 && !scriptSource.isPlaying)
        {
            player.disabled = false;
            stepIntro++;
        }

        if (player.GetComponent<Transform>().position.y < -6 && !hasFallen)
        {
            player.disabled = true;
            isFalling = true;
            hasFallen = true;
            if (!hasReload)
            {
                scriptSource = SoundManager.instance.PlayVoice(fall, new Vector3(0, 0));
            }
            else
            {
                scriptSource = SoundManager.instance.PlayVoice(fallAgain, new Vector3(0, 0));
            }
        }

        if (isFalling && !scriptSource.isPlaying)
        {
            player.disabled = false;
            isFalling = false;
        }

        if (player.GetComponent<Transform>().position.x > 1 && hasReload && !hasFinished)
        {
            player.disabled = true;
            isCongrats = true;
            hasFinished = true;
            scriptSource = SoundManager.instance.PlayVoice(congrats, new Vector3(0, 0));
        }

        if (isCongrats && !scriptSource.isPlaying)
        {
            player.disabled = false;
            isCongrats = false;
        }
    }
}
