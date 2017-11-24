using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public enum UIState
    {
        Train,
        Station,
        PauseMenu
    }

    public UIState uiState;

    void Update()
    {
        
    }

    public void ChangeUIState()
    {
        if(Input.GetButtonDown("Escape"))
        {
            if (uiState == UIState.Train)
            {
                uiState = UIState.PauseMenu;
            }
            else if (uiState == UIState.Station)
            {
                uiState = UIState.Train;
            }
            else if (uiState == UIState.PauseMenu)
            {
                uiState = UIState.Train;
            }
        }
    }


}
