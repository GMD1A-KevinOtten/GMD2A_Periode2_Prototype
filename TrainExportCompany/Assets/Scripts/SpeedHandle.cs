using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpeedHandle : MonoBehaviour {
    public Train train;

    public float maxSpeed;
    public float minSpeed;

    public Text speedometer;
	// Use this for initialization
	void Start () {
        train = GameObject.FindGameObjectWithTag("Train").GetComponent<Train>();
       
	}
	
	// Update is called once per frame
	void Update () {
		if(train.speed < 0)
        {
            train.speed = 0;
        }

        if(speedometer != null)
        {
            float i = train.speed * 10;
            speedometer.text =  i.ToString("F0") + "KM/H";

        }
       
	}

    public void SpeedRegulator(string dir)
    {
        if(dir == "Up")
        {
            if(train.speed < maxSpeed)
            {
                train.speed += 0.2F;
            }
        }
        else if(dir == "Down")
        {
            if (train.speed > minSpeed)
            {
                train.speed -= 0.2F;
            }
        }
    }
}
