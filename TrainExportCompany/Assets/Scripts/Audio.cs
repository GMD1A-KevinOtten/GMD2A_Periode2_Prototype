using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

    public AudioSource cameraSource;
    public AudioSource cameraMusicSource;
    public List<AudioClip> music = new List<AudioClip>();
    public List<AudioClip> soundEffect = new List<AudioClip>();
    public int currentSong;
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
        if(currentSong < music.Count)
        {
            cameraMusicSource.clip = music[currentSong];
            ui.CurrentSongText();
            cameraMusicSource.Play();
            currentSong += 1;
        }
        else if(currentSong >= music.Count)
        {
            currentSong = 0;
            cameraMusicSource.clip = music[currentSong];
            ui.CurrentSongText();
            cameraMusicSource.Play();
            currentSong += 1;
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
