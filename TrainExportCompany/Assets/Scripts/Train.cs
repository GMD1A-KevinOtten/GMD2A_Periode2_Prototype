using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour {
    public float speed;
    public float cartOffset;

    public List<GameObject> trainCarts = new List<GameObject>();
	// Use this for initialization
	void Start () {
        GetComponent<WaypointsNew>().speed = speed;
	}
	
	// Update is called once per frame
	void Update () {
        if(GetComponent<WaypointsNew>().speed != speed)
        {
            GetComponent<WaypointsNew>().speed = speed;
        }
    }
}
