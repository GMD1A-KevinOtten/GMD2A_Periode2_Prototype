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

    void Start()
    {
        gIron = RandomStockGen();
        gOre = RandomStockGen();
        gGrain = RandomStockGen();
        gCoal = RandomStockGen();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Train" && !inStation && other.GetComponent<Train>().speed == 0)
        {
            cargo = other.GetComponent<Cargo>();
            ui.UpdateStationInfo(this);
            inStation = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Train" && inStation)
        {
            inStation = false;
        }
    }

    public int RandomStockGen()
    {
        int randomStock = Random.Range(-5, 5) * 100;
        return randomStock;
    }
}
