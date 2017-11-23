using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public void Quit()
    {
        GameManager.QuitGame();
    }

    public void Start()
    {
        GameManager.SceneChance(1);
    }
}
