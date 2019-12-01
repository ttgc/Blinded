using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endScript : MonoBehaviour
{
    private AudioSource scriptSource;
    private bool finished = false;

    public AudioClip finalScript;

    // Start is called before the first frame update
    void Start()
    {
        scriptSource = SoundManager.instance.efxSource;
        SoundManager.instance.PlayClip(finalScript, new Vector3(0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (!finished && !scriptSource.isPlaying)
        {
            finished = true;
            // THE END
            Debug.Break();
        }
    }
}
