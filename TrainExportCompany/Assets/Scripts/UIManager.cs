using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    //Enum
    public enum UIState
    {
        PauseMenu,
        Train,
        Station
    }
    public UIState uiState;
    public AudioGameManager agm;
    //Station
    public Stations station;
    //Pannels
    public GameObject pausePanel;
    public GameObject trainPanel;
    public GameObject stationPanel;
    private GameObject lastPanel;
    //StationTexst
    public Text gOneText;
    public Text gTwoText;
    public Text gThreeText;
    public Text gFourText;
    public Text stationMessage;
    public Text carIron;
    public Text carOre;
    public Text carGrain;
    public Text carCoal;

    void Start()
    {
        ChangeUIState();
        agm = GameObject.FindWithTag("MainCamera").GetComponent<AudioGameManager>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Escape"))
        {
            print("Escape");
            ChangeUIState();
        }
    }

    //UI Chance
    public void ChangeUIState()
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
            Time.timeScale = 1;
                uiState = UIState.Train;
            }
            ChangeUI();
    }

    public void ChangeUI()
    {
        //Valnet over een null refrence error
        if(lastPanel != null)
        {
            lastPanel.SetActive(false);
        }


        if (uiState == UIState.PauseMenu)
        {
            pausePanel.SetActive(true);
            lastPanel = pausePanel;
            Time.timeScale = 0;
        }
        else if (uiState == UIState.Train)
        {
            trainPanel.SetActive(true);
            lastPanel = trainPanel;
        }
        else if (uiState == UIState.Station)
        {
            stationPanel.SetActive(true);
            lastPanel = stationPanel;
        }
    }

    //UI PauseMenu
    public void ReturnToGame()
    {
        Time.timeScale = 1;
        ChangeUIState();
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        GameManager.SceneChance(0);
    }

    //UI Train


    //UI Station

    public void UpdateStationInfo(Stations currentStation)
    {
        uiState = UIState.Station;
        ChangeUI();
        station = currentStation;
        UpdateStationUI();
    }

    public void UpdateStationUI()
    {
        gOneText.text = "Iron: " + station.gIron;
        gTwoText.text = "Ore: " + station.gOre;
        gThreeText.text = "Grain: " + station.gGrain;
        gFourText.text = "Coal: " + station.gCoal;

        carIron.text = "Iron: " + station.cargo.cargoIron;
        carOre.text = "Ore: " + station.cargo.cargoOre;
        carGrain.text = "Grain: " + station.cargo.cargoGrain;
        carCoal.text = "Coal: " + station.cargo.cargoCoal;
    }

    public void Buy(int GoodsType)
    {
        if(GoodsType == 1)
        {
            if (station.gIron >= 100 && station.cargo.cashMoney >= 5)
            {
                agm.TriggerChaChing();
                station.cargo.cashMoney -= 5;
                station.gIron -= 10;
                station.cargo.cargoIron += 10;
                UpdateStationUI();
            }
            else if (station.gIron >= 10 && station.cargo.cashMoney >= 10)
            {
                agm.TriggerChaChing();
                station.cargo.cashMoney -= 10;
                station.gIron -= 10;
                station.cargo.cargoIron += 10;
                UpdateStationUI();
            }
            else if (station.gIron < 10)
            {
                StationMessage("There is not enough produce");
            }
            else if (station.cargo.cashMoney < 10)
            {
                StationMessage("Not enough CashMoney");
            }
        }
        else if(GoodsType == 2)
        {
            if (station.gOre >= 100 && station.cargo.cashMoney >= 5)
            {
                agm.TriggerChaChing();
                station.cargo.cashMoney -= 5;
                station.gOre -= 10;
                station.cargo.cargoOre += 10;
                UpdateStationUI();
            }
            else if (station.gOre >= 10 && station.cargo.cashMoney >= 10)
            {
                agm.TriggerChaChing();
                station.cargo.cashMoney -= 10;
                station.gOre -= 10;
                station.cargo.cargoOre += 10;
                UpdateStationUI();
            }
            else if (station.gOre < 10)
            {
                StationMessage("There is Not enough produce");
            }
            else if (station.cargo.cashMoney < 10)
            {
                StationMessage("Not enough CashMoney");
            }
        }
        else if(GoodsType == 3)
        {
            if (station.gGrain >= 100 && station.cargo.cashMoney >= 5)
            {
                agm.TriggerChaChing();
                station.cargo.cashMoney -= 5;
                station.gGrain -= 10;
                station.cargo.cargoGrain += 10;
                UpdateStationUI();
            }
            else if (station.gGrain >= 10 && station.cargo.cashMoney >= 10)
            {
                agm.TriggerChaChing();
                station.cargo.cashMoney -= 10;
                station.gGrain -= 10;
                station.cargo.cargoGrain += 10;
                UpdateStationUI();
            }
            else if (station.gGrain < 10)
            {
                StationMessage("There is Not enough produce");
            }
            else if (station.cargo.cashMoney < 10)
            {
                StationMessage("Not enough CashMoney");
            }
        }
        else if(GoodsType == 4)
        {
            if (station.gCoal >= 100 && station.cargo.cashMoney >= 5)
            {
                agm.TriggerChaChing();
                station.cargo.cashMoney -= 5;
                station.gCoal -= 10;
                station.cargo.cargoCoal += 10;
                UpdateStationUI();
            }
            else if (station.gCoal >= 10 && station.cargo.cashMoney >= 10)
            {
                agm.TriggerChaChing();
                station.cargo.cashMoney -= 10;
                station.gCoal -= 10;
                station.cargo.cargoCoal += 10;
                UpdateStationUI();
            }
            else if (station.gCoal < 10)
            {
                StationMessage("There is Not enough produce");
            }
            else if (station.cargo.cashMoney < 10)
            {
                StationMessage("Not enough CashMoney");
            }
        }
    }

    public void Sell(int GoodsType)
    {
        if (GoodsType == 1)
        {
            if(station.gIron <= -100 && station.cargo.cargoIron >= 10)
            {
                agm.TriggerChaChing();
                station.cargo.cashMoney += 20;
                station.gIron += 10;
                station.cargo.cargoIron -= 10;
                UpdateStationUI();
            }
            else if (station.gIron <= -50 && station.cargo.cargoIron >= 10)
            {
                agm.TriggerChaChing();
                station.cargo.cashMoney += 10;
                station.gIron += 10;
                station.cargo.cargoIron -= 10;
                UpdateStationUI();
            }
            else if (station.gIron <= 0 && station.cargo.cargoIron >= 10)
            {
                agm.TriggerChaChing();
                station.cargo.cashMoney += 5;
                station.gIron += 10;
                station.cargo.cargoIron -= 10;
                UpdateStationUI();
            }
            else if (station.gIron > 0 && station.cargo.cargoIron >= 10)
            {
                agm.TriggerChaChing();
                station.cargo.cashMoney += 1;
                station.gIron += 10;
                station.cargo.cargoIron -= 10;
                UpdateStationUI();
            }
            else if(station.cargo.cargoIron < 10)
            {
                StationMessage("You don't have enough cargo");
            }
            else if(station.gIron >= 500)
            {
                StationMessage("There is no Demand or there is too much suplly for this recource");
            }
        }
        else if (GoodsType == 2)
        {
            if (station.gOre <= -100 && station.cargo.cargoOre >= 10)
            {
                agm.TriggerChaChing();
                station.cargo.cashMoney += 20;
                station.gOre += 10;
                station.cargo.cargoOre -= 10;
                UpdateStationUI();
            }
            else if (station.gOre <= -50 && station.cargo.cargoOre >= 10)
            {
                agm.TriggerChaChing();
                station.cargo.cashMoney += 10;
                station.gOre += 10;
                station.cargo.cargoOre -= 10;
                UpdateStationUI();
            }
            else if (station.gOre <= 0 && station.cargo.cargoOre >= 10)
            {
                agm.TriggerChaChing();
                station.cargo.cashMoney += 5;
                station.gOre += 10;
                station.cargo.cargoOre -= 10;
                UpdateStationUI();
            }
            else if (station.gOre > 0 && station.cargo.cargoOre >= 10)
            {
                agm.TriggerChaChing();
                station.cargo.cashMoney += 1;
                station.gOre += 10;
                station.cargo.cargoOre -= 10;
                UpdateStationUI();
            }
            else if (station.cargo.cargoOre < 10)
            {
                StationMessage("You don't have enough cargo");
            }
            else if(station.gOre >= 500)
            {
                StationMessage("There is no Demand or there is too much suplly for this recource");
            }
        }
        else if (GoodsType == 3)
        {
            if (station.gGrain <= -100 && station.cargo.cargoGrain >= 10)
            {
                agm.TriggerChaChing();
                station.cargo.cashMoney += 20;
                station.gGrain += 10;
                station.cargo.cargoGrain -= 10;
                UpdateStationUI();
            }
            else if (station.gGrain <= -50 && station.cargo.cargoGrain >= 10)
            {
                agm.TriggerChaChing();
                station.cargo.cashMoney += 10;
                station.gGrain += 10;
                station.cargo.cargoGrain -= 10;
                UpdateStationUI();
            }
            else if (station.gGrain <= 0 && station.cargo.cargoGrain >= 10)
            {
                agm.TriggerChaChing();
                station.cargo.cashMoney += 5;
                station.gGrain += 10;
                station.cargo.cargoGrain -= 10;
                UpdateStationUI();
            }
            else if (station.gGrain > 0 && station.cargo.cargoGrain >= 10)
            {
                agm.TriggerChaChing();
                station.cargo.cashMoney += 1;
                station.gGrain += 10;
                station.cargo.cargoGrain -= 10;
                UpdateStationUI();
            }
            else if (station.cargo.cargoGrain < 10)
            {
                StationMessage("You don't have enough cargo");
            }
            else if (station.gGrain >= 500)
            {
                StationMessage("There is no Demand or there is too much suplly for this recource");
            }
        }
        else if (GoodsType == 4)
        {
            if (station.gCoal <= -100 && station.cargo.cargoCoal >= 10)
            {
                agm.TriggerChaChing();
                station.cargo.cashMoney += 20;
                station.gCoal += 10;
                station.cargo.cargoCoal -= 10;
                UpdateStationUI();
            }
            else if (station.gCoal <= -50 && station.cargo.cargoCoal >= 10)
            {
                agm.TriggerChaChing();
                station.cargo.cashMoney += 10;
                station.gCoal += 10;
                station.cargo.cargoCoal -= 10;
                UpdateStationUI();
            }
            else if (station.gCoal <= 0 && station.cargo.cargoCoal >= 10)
            {
                agm.TriggerChaChing();
                station.cargo.cashMoney += 5;
                station.gCoal += 10;
                station.cargo.cargoCoal -= 10;
                UpdateStationUI();
            }
            else if (station.gCoal > 0 && station.cargo.cargoCoal >= 10)
            {
                agm.TriggerChaChing();
                station.cargo.cashMoney += 1;
                station.gCoal += 10;
                station.cargo.cargoCoal -= 10;
                UpdateStationUI();
            }
            else if (station.cargo.cargoCoal < 10)
            {
                StationMessage("You don't have enough cargo");
            }
            else if (station.gCoal >= 500)
            {
                StationMessage("There is no Demand or there is suplly for this recource");
            }
        }
    }

    public void StationMessage(string message)
    {
        stationMessage.text = message;
    }
}
