using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rails : MonoBehaviour {
    public List<GameObject> myNeighbours = new List<GameObject>();
    public List<GameObject> myWaypoints = new List<GameObject>();
    public bool left;
    public bool right;
    public bool back;

    public GameObject connectedSwitch;
  
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

    void OnCollisionEnter(Collision col)
    {
        if(col.transform.tag == "BigSwitch")
        {
            foreach(Transform t in col.transform)
            {
                if(t.tag == "Switch" && connectedSwitch == null)
                {
                    connectedSwitch = t.gameObject;
                }
            }
        }
        if(col.transform.tag == "Rails")
        {
            
                foreach(GameObject g in col.transform.GetComponent<Rails>().myWaypoints)
                {
                    if (!myWaypoints.Contains(col.gameObject))
                    {
                        myWaypoints.Add(g);
                    }
                 }

                    if(connectedSwitch != null)
            {
                myWaypoints.Add(connectedSwitch);
            }
            
        }
    }
}
