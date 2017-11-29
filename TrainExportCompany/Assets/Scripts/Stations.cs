using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stations : MonoBehaviour {

    public int gIron;
    public int gOre;
    public int gGrain;
    public int gCoal;
    public Cargo cargo;
    public UIManager ui;
    public static bool inStation;


    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Train" && inStation == false)// && train.speed == 0)
        {
            ui.UpdateStationInfo(this);
            inStation = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Train" && inStation == true)
        {
            ui.ChangeUIState();
            inStation = false;
        }
    }

}
