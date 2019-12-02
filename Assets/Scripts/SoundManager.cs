using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject player;
    private AudioSource efxSource;
    private AudioSource efxSource1;
    private AudioSource efxSource2;
    private AudioSource efxSource3;
    private AudioSource musicSource;
    private AudioSource voiceSource;
    public AudioClip ambiant;
    public static SoundManager instance = null;
    public float minX = -10.0F;
    public float maxX = 10.0F;

    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        var sources = GetComponents<AudioSource>();
        efxSource = sources[0];
        efxSource1 = sources[1];
        efxSource2 = sources[2];
        efxSource3 = sources[3];
        musicSource = sources[4];
        voiceSource = sources[5];
    }

    void Start()
    {
        musicSource.loop = true;
        musicSource.clip = ambiant;
        musicSource.Play();
    }

    public AudioSource PlayVoice(AudioClip voiceClip, Vector3 position)
    {
        voiceSource.panStereo = ConvertPosToPan(position);
        voiceSource.clip = voiceClip;
        voiceSource.Play();
        return voiceSource;
    }

    public AudioSource PlayClip(AudioClip clip, Vector3 position)
    {
        if (!efxSource.isPlaying)
        {
            efxSource.panStereo = ConvertPosToPan(position);
            efxSource.clip = clip;
            efxSource.Play();
            return efxSource;
        }
        else if (!efxSource1.isPlaying)
        {
            efxSource1.panStereo = ConvertPosToPan(position);
            efxSource1.clip = clip;
            efxSource1.Play();
            return efxSource1;
        }
        else if (!efxSource2.isPlaying)
        {
            efxSource2.panStereo = ConvertPosToPan(position);
            efxSource2.clip = clip;
            efxSource2.Play();
            return efxSource2;
        }
        else if (!efxSource3.isPlaying)
        {
            efxSource3.panStereo = ConvertPosToPan(position);
            efxSource3.clip = clip;
            efxSource3.Play();
            return efxSource3;
        }
        else
        {
            efxSource.panStereo = ConvertPosToPan(position);
            efxSource.clip = clip;
            efxSource.Play();
            return efxSource;
        }
    }

    public float ConvertPosToPan(Vector3 pos)
    {
        return pos.x / 10;
    }

    public AudioSource PlayRandomClip(AudioClip[] clips, Vector3 position)
    {
        int randomIndex = Random.Range(0, clips.Length);
        return this.PlayClip(clips[randomIndex], position);
    }


    void Update()
    {

    }
}
