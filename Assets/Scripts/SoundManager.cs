using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject player;
    public AudioSource efxSource;
    public AudioSource efxSource1;
    public AudioSource efxSource2;
    public AudioSource musicSource;
    public static SoundManager instance = null;
    public float minX = -10.0F;
    public float maxX = 10.0F;


    void Awake ()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy (gameObject);
        DontDestroyOnLoad (gameObject);
    }

    void Start()
    {
        
    }

    public void PlayClip(AudioClip clip, Vector3 position)
    {
        if (!efxSource.isPlaying) {
            efxSource.panStereo = ConvertPosToPan(position);
            efxSource.clip = clip;
            efxSource.Play ();
        } else if (!efxSource1.isPlaying) {
            efxSource1.panStereo = ConvertPosToPan(position);
            efxSource1.clip = clip;
            efxSource1.Play ();
        } else if (!efxSource2.isPlaying) {
            efxSource2.panStereo = ConvertPosToPan(position);
            efxSource2.clip = clip;
            efxSource2.Play ();
        } else {
            efxSource.panStereo = ConvertPosToPan(position);
            efxSource.clip = clip;
            efxSource.Play ();
        }
    }

    public float ConvertPosToPan(Vector3 pos) {
        return pos.x/10;
    }

    public void PlayRandomClip(AudioClip[] clips, Vector3 position)
    {
        int randomIndex = Random.Range(0, clips.Length);
        this.PlayClip(clips[randomIndex], position);
    }


    void Update()
    {
        
    }
}
