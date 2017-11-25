using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteSwitch : MonoBehaviour {

    public List<GameObject> rightWaypoints = new List<GameObject>();
    public List<GameObject> leftWaypoints = new List<GameObject>();
    public List<GameObject> backWaypoints = new List<GameObject>();

    public string lockedDir;
    public bool goLeft;
    public bool goRight;
    public bool goBack;

    private TextMesh dirText;
    public GameObject wpTrainCameFrom;

    void Start () {
        dirText = GetComponentInChildren<TextMesh>();
        if (goRight)
        {
            dirText.text = "Right";
        }
        else if (goLeft)
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

            if (goRight && lockedDir != "Left")
            {
                foreach (GameObject g in rightWaypoints)
                {
                    trainWayPoints.wp.Add(g);
                }
                trainWayPoints.SetNextSwitch();

                lockedDir = "Left";



            }
            else if (goLeft && lockedDir != "Right")
            {
                foreach (GameObject g in leftWaypoints)
                {
                    trainWayPoints.wp.Add(g);
                }
                trainWayPoints.SetNextSwitch();
                lockedDir = "Right";


            }
            else if(lockedDir == "Right")
            {
                if (goLeft)
                {
                    foreach (GameObject g in leftWaypoints)
                    {
                        trainWayPoints.wp.Add(g);
                    }
                    trainWayPoints.SetNextSwitch();
                }
               else if (goBack)
                {
                    foreach (GameObject g in backWaypoints)
                    {
                        trainWayPoints.wp.Add(g);
                    }
                    trainWayPoints.SetNextSwitch();
                    lockedDir = "Back";
                }
                
            }
            else if (lockedDir == "Left")
            {
                if (goRight)
                {
                    foreach (GameObject g in rightWaypoints)
                    {
                        trainWayPoints.wp.Add(g);
                    }
                    trainWayPoints.SetNextSwitch();
                }
                else if (goBack)
                {
                    foreach (GameObject g in backWaypoints)
                    {
                        trainWayPoints.wp.Add(g);
                    }
                    trainWayPoints.SetNextSwitch();

                    lockedDir = "Back";
                }

            }

        }

        }

    public void CheckWaypointBeforeSwitch()
    {
        if(wpTrainCameFrom != null)
        {
            if (wpTrainCameFrom == backWaypoints[0] && lockedDir != "Back")
            {
                lockedDir = "Back";
                goBack = false;
            }

        }
    }
    }
