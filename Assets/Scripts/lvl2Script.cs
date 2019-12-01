using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl2Script : MonoBehaviour
{
    private simpleMovement player;
    private boxpull box;
    private door door_;
    private static int step = 0;
    private AudioSource scriptSource;

    public AudioClip intro;
    public AudioClip middle;
    public AudioClip end;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<simpleMovement>();
        box = GameObject.FindObjectOfType<boxpull>();
        door_ = GameObject.FindObjectOfType<door>();
        if (step == 0)
        {
            player.disabled = true;
            scriptSource = SoundManager.instance.PlayVoice(intro, new Vector3(0, 0));
            step++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((step == 1 || step == 3 || step == 5) && !scriptSource.isPlaying)
        {
            player.disabled = false;
            step++;
        }

        if (player.GetComponent<Transform>().position.x > -1 && step == 2)
        {
            player.disabled = true;
            scriptSource = SoundManager.instance.PlayVoice(middle, new Vector3(-4, 0));
            step++;
        }

        var boxpos = box.GetComponent<Transform>();
        if (boxpos.position.x < -3 && boxpos.position.x > -5 && door_.doorOpen && !box.beingPushed && step == 4)
        {
            player.disabled = true;
            scriptSource = SoundManager.instance.PlayVoice(end, new Vector3(0, 0));
            step++;
        }
    }
}
