using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource efxSource;
    public AudioSource musicSource;
    public static SoundManager instance = null;

    void Awake ()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy (gameObject);
        DontDestroyOnLoad (gameObject);
    }

    void Start()
    {
        
    }

    public void PlayClip(AudioClip clip, float panStereo = 0.0F)
    {
        efxSource.panStereo = panStereo;
        efxSource.clip = clip;
        efxSource.Play ();
    }

    public void PlayRandomClip(AudioClip[] clips, float panStereo = 0.0F)
    {
        int randomIndex = Random.Range(0, clips.Length);
        this.PlayClip(clips[randomIndex], panStereo);
    }


    void Update()
    {
        
    }
}
