using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public void Quit()
    {
        GameManager.QuitGame();
    }

    public void Play()
    {
        GameManager.SceneChance(1);
    }
}
