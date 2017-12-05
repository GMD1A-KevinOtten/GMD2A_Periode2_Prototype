using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rails : MonoBehaviour {
    public List<GameObject> myWaypoints = new List<GameObject>();
    public bool reverseWaypoints;
	// Use this for initialization
	void Start () {
		foreach(Transform t in transform)
        {
            if(t.tag == "Waypoint")
            {
                myWaypoints.Add(t.gameObject);
            }
        }

        if (reverseWaypoints)
        {
            myWaypoints.Reverse();
        }


	}
	
	// Update is called once per frame
	void Update () {
		
	}

   
}
