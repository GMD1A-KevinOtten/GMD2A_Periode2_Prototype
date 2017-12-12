using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

    public AudioSource cameraSource;
    public AudioSource cameraMusicSource;
    public List<AudioClip> music = new List<AudioClip>();
    public List<AudioClip> soundEffect = new List<AudioClip>();
    public int currentSong = -1;
    public UIManager ui;

    void Update()
    {
        if(cameraMusicSource.isPlaying == false)
        {
            NextSong();
        }
    }

    public void NextSoundEffect(int index)
    {
        cameraSource.clip = soundEffect[index];
        cameraSource.Play();
    }

    public void NextSong()
    {
        if(currentSong < music.Count -1)
        {
            currentSong += 1;
            cameraMusicSource.clip = music[currentSong];
            ui.CurrentSongText();
            cameraMusicSource.Play();
        }
        else if(currentSong >= music.Count -1)
        {
            currentSong = 0;
            cameraMusicSource.clip = music[currentSong];
            ui.CurrentSongText();
            cameraMusicSource.Play();
        }
    }

    public void SycleSongBackwards()
    {
        if(currentSong != 0)
        {
            currentSong -= 1;
            cameraMusicSource.clip = music[currentSong];
            ui.CurrentSongText();
            cameraMusicSource.Play();
        }
        else if(currentSong == 0)
        {
            currentSong = music.Count -1;
            cameraMusicSource.clip = music[currentSong];
            ui.CurrentSongText();
            cameraMusicSource.Play();
        }
    }
}
