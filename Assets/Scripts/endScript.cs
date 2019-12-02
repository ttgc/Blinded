using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endScript : MonoBehaviour
{
    private AudioSource scriptSource;

    public AudioClip finalScript;

    // Start is called before the first frame update
    void Start()
    {
        scriptSource = SoundManager.instance.PlayClip(finalScript, new Vector3(0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (!scriptSource.isPlaying)
        {
            Debug.Break();
            SceneManager.LoadScene(0);
        }
    }
}
