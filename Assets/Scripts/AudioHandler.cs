using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AudioHandler : MonoBehaviour
{

    public static AudioHandler instance;


    public AudioSource MusicSource;
    public AudioClip forestClip;

    public AudioSource JumpAudio;
    public AudioSource RollAudio;
    public AudioClip JumpSound;
    public AudioClip RollSound;

    public AudioClip[] GroundSounds;

    public float MusicVolume;
    public float SFXVolume;

    void Start()
    {
        JumpAudio = gameObject.AddComponent<AudioSource>();
        RollAudio = gameObject.AddComponent<AudioSource>();
        LoadSounds();
    }

    void Update()
    {
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume", 1); ;
        JumpAudio.volume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        RollAudio.volume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
    }

    void LoadSounds()
    {
        GroundSounds = new AudioClip[5];

        for (int i = 0; i < GroundSounds.Length; i++)
        {
            GroundSounds[i] = (AudioClip) Resources.Load("Sounds/step" + i);
        }
    }


    /*IEnumerator loopClips()
    {
        for (int i = 0; i < RunSound.Length; i++)
        {
            if (!this.GetComponent<PlayerHandler>().isOnGround
                || this.GetComponent<PlayerHandler>().isRolling
                || this.GetComponent<PlayerHandler>().isDead)
            {
                this.GetComponent<PlayerHandler>().isRunning = false;
                playerSounds.Stop();
                yield break;
            }
                
            playerSounds.clip = RunSound[i];
            playerSounds.Play();
            yield return new WaitForSeconds(0.3f);
        }
        this.GetComponent<PlayerHandler>().isRunning = false;
    }*/

    /*public void playRunSound()
    {
        playerSounds.Stop();
        StartCoroutine(loopClips());
    }*/

    /*public void DownloadMusic()
    {
        StartCoroutine(DownloadClip("http://localhost:8000/sound/forest.ogg", AudioType.OGGVORBIS));
    }

    IEnumerator DownloadClip(string URL, AudioType AudioType)
    {
        using (UnityWebRequest www2 = UnityWebRequestMultimedia.GetAudioClip(URL, AudioType))
        {
            yield return www2.SendWebRequest();

            if (www2.isHttpError)
            {
                Debug.Log(www2.error);
            }
            else
            {
                this.forestClip = DownloadHandlerAudioClip.GetContent(www2);
            }
        }
    }*/


    /*public void DownloadAll()
    {
        URLs = new string[5];
        for (int i = 0; i < URLs.Length; i++)
            URLs[i] = "http://192.168.0.10:8000/sound/step" + (i + 1).ToString() + ".ogg";

        WavFiles = new AudioClip[5];

        for (int i = 0; i < URLs.Length; i++)
        {
            StartCoroutine(DownloadWavList(URLs[i], i));
        }

    }*/

    /*IEnumerator DownloadWavList(string URL, int index)
    {
        using (UnityWebRequest www2 = UnityWebRequestMultimedia.GetAudioClip(URL, AudioType.OGGVORBIS))
        {
            yield return www2.SendWebRequest();

            if (www2.isHttpError)
            {
                Debug.Log(www2.error);
            }
            else
            {
                AudioClip downloadedClip = DownloadHandlerAudioClip.GetContent(www2);
                WavFiles[index] = downloadedClip;
            }
        }
    }*/

    public void PlayJumpSound()
    {
        JumpAudio.Stop();
        RollAudio.Stop();
        JumpSound = GroundSounds[new System.Random().Next(0, GroundSounds.Length)];
        JumpAudio.PlayOneShot(JumpSound);
    }
    public void PlayRollSound()
    {
        RollAudio.Stop();
        JumpAudio.Stop();
        RollSound = GroundSounds[new System.Random().Next(0, GroundSounds.Length)];
        RollAudio.PlayOneShot(RollSound);
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        //MusicSource = gameObject.AddComponent<AudioSource>();
        //DownloadMusic();
        //PlayMusic();
        //DownloadAll();
    }

    /*public void PlayMusic()
    {
        MusicSource.loop = true;
        StartCoroutine(LoadMusic());
        Debug.Log(MusicSource.clip);
        if (!MusicSource.isPlaying) MusicSource.PlayOneShot(forestClip, 5);
    }

    IEnumerator LoadMusic()
    {
         yield return new WaitForSeconds(10);
         MusicSource.clip = forestClip;
        
    }*/
}
