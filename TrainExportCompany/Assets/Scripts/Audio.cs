using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

    public AudioSource cameraSource;
    public AudioSource cameraMusicSource;
    public List<AudioClip> music = new List<AudioClip>();
    public List<AudioClip> soundEffect = new List<AudioClip>();
    public int currentSong;

    void Update()
    {
        if(cameraMusicSource.isPlaying == false)
        {
            NextSong();
        }
    }

    public void TriggerChaChing()
    {
        cameraSource.clip = soundEffect[0];
        cameraSource.Play();
    }

    public void NextSong()
    {
        if(currentSong < music.Count)
        {
            print("fuck");
            cameraMusicSource.clip = music[currentSong];
            currentSong += 1;
            cameraMusicSource.Play();
        }
        else
        {
            print("Mooi");
            currentSong = 0;
            cameraMusicSource.clip = music[currentSong];
            cameraMusicSource.Play();
        }
    }
}
