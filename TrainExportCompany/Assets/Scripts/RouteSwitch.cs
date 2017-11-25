using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteSwitch : MonoBehaviour {
    public bool turnRight;
    public GameObject nextSwitch;

    //public bool turnedRightLastTime;
    //public bool trainPassedOnce;

    public List<GameObject> rightWaypoints = new List<GameObject>();
    public List<GameObject> leftWaypoints = new List<GameObject>();

    private TextMesh dirText;
    public GameObject wpTrainCameFrom;

    void Start () {
        dirText = GetComponentInChildren<TextMesh>();

        if (turnRight)
        {
            dirText.text = "Right";
        }
        else if (!turnRight)
        {
            dirText.text = "Left";
        }
    }
	
	// Update is called once per frame
	void Update () {
        //UpdateText();

    }

    void UpdateText()
    {
   
    }

    void OnTriggerEnter(Collider other)
    {

        if(other.transform.tag == "Train")
        {
            WaypointsNew trainWayPoints = other.GetComponent<WaypointsNew>();



    

            if (turnRight)
            {
                foreach(GameObject g in rightWaypoints)
                {
                    trainWayPoints.wp.Add(g);
                }
               
            }
            else if (!turnRight)
            {
                foreach (GameObject g in leftWaypoints)
                {
                    trainWayPoints.wp.Add(g);
                }
               
            }
           
          }

        }
    }
