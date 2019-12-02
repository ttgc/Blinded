using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    internal enum Options { NEW = 0, LOAD = 1, QUIT = 2 }

    private Options selected = Options.NEW;
    private GameSaver gameSaved = new GameSaver() { level = 1 };
    private AudioSource musicSource;
    private AudioSource voiceSource;
    public AudioClip music;
    public AudioClip voice_newgame;
    public AudioClip voice_loadgame;
    public AudioClip voice_quitgame;

    void Awake()
    {
        var sources = GetComponents<AudioSource>();
        musicSource = sources[0];
        voiceSource = sources[1];
    }

    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/" + GameSaver.filename))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + GameSaver.filename, FileMode.Open);
            gameSaved = (GameSaver)bf.Deserialize(file);
            file.Close();
        }

        musicSource.loop = true;
        musicSource.clip = music;
        musicSource.Play();

        playVoice(voice_newgame);
    }

    private void playVoice(AudioClip clip)
    {
        voiceSource.clip = clip;
        voiceSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            switch(selected)
            {
                case Options.NEW:
                    selected = Options.LOAD;
                    playVoice(voice_loadgame);
                    break;
                case Options.LOAD:
                    selected = Options.QUIT;
                    playVoice(voice_quitgame);
                    break;
                case Options.QUIT:
                    selected = Options.NEW;
                    playVoice(voice_newgame);
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            switch (selected)
            {
                case Options.NEW:
                    selected = Options.QUIT;
                    playVoice(voice_quitgame);
                    break;
                case Options.LOAD:
                    selected = Options.NEW;
                    playVoice(voice_newgame);
                    break;
                case Options.QUIT:
                    selected = Options.LOAD;
                    playVoice(voice_loadgame);
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            switch (selected)
            {
                case Options.NEW:
                    newgame();
                    break;
                case Options.LOAD:
                    loadgame();
                    break;
                case Options.QUIT:
                    quit();
                    break;
            }
        }
    }

    public void newgame()
    {
        SceneManager.LoadScene(1);
    }

    public void loadgame()
    {
        SceneManager.LoadScene(gameSaved.level);
    }

    public void quit()
    {
        Application.Quit();
    }
}
