using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rails : MonoBehaviour {
    public List<GameObject> myWaypoints = new List<GameObject>();
  
	// Use this for initialization
	void Start () {
		foreach(Transform t in transform)
        {
            if(t.tag == "Waypoint")
            {
                myWaypoints.Add(t.gameObject);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   
}
