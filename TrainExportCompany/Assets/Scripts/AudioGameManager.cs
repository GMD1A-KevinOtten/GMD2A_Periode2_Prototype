using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGameManager : MonoBehaviour {

    public AudioSource cameraSource;

    public void TriggerChaChing()
    {
        cameraSource.Play();
    }
}
