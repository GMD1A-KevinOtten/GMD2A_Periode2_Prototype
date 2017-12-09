﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteSwitch : MonoBehaviour {

    public List<GameObject> rightRails = new List<GameObject>();
    public List<GameObject> leftRails = new List<GameObject>();
    public List<GameObject> backRails = new List<GameObject>();

    public List<GameObject> rightWaypoints = new List<GameObject>();
    public List<GameObject> leftWaypoints = new List<GameObject>();
    public List<GameObject> backWaypoints = new List<GameObject>();

    public List<GameObject> backWaypointsLeft = new List<GameObject>();
    public List<GameObject> backWaypointsLRight = new List<GameObject>();

    public List<GameObject> nextSwitches = new List<GameObject>();

    public string lockedDir;
    public bool goLeft;
    public bool goRight;
    public bool goBack;

    private TextMesh dirText;
    public GameObject wpTrainCameFrom;

    public bool trainPassing;
    public bool cameFromBack;

    private WaypointsNew tren;
    private bool backWLReversed;
    private bool backWRReversed;

    void Start () {
        tren = GameObject.FindGameObjectWithTag("Train").GetComponent<WaypointsNew>();
        StartCoroutine(WaitToLoad());






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
       

    }

    IEnumerator WaitToLoad()
    {
        yield return new WaitForSeconds(1);
        foreach (GameObject g in rightRails)
        {
            if(g != null)
            {
                if(g.tag != "SwitchBig")
                {
                    foreach (GameObject q in g.GetComponent<Rails>().myWaypoints)
                    {
                        if (!rightWaypoints.Contains(q))
                        {
                            rightWaypoints.Add(q);
                        }
                    }

                }

            }
        }
        //Switches 0 = links 1 = rechts 2 = back
        rightWaypoints.Add(nextSwitches[1]);

        foreach (GameObject g in leftRails)
        {
            if(g != null)
            {
                if (g.tag != "SwitchBig")
                {
                        foreach (GameObject q in g.GetComponent<Rails>().myWaypoints)
                    {
                        if (!leftWaypoints.Contains(q))
                        {
                            leftWaypoints.Add(q);
                        }
                    }

                }

            }

        }

        leftWaypoints.Add(nextSwitches[0]);

        foreach (GameObject g in backRails)
        {
            if(g != null)
            {
                if (g.tag != "SwitchBig")
                {
                        foreach (GameObject q in g.GetComponent<Rails>().myWaypoints)
                    {
                        if (!backWaypoints.Contains(q))
                        {
                            backWaypoints.Add(q);
                        }
                    }

                }

            }

        }

        backWaypoints.Add(nextSwitches[2]);
    }


    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Train" || other.transform.tag == "AITrain" || other.transform.tag == "PlayerCart" || other.transform.tag == "AICart")
        {
            trainPassing = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
       
        
        if(other.transform.tag == "Train" || other.transform.tag == "AITrain")
        {
           
            WaypointsNew trainWayPoints = other.GetComponent<WaypointsNew>();

            if (goRight && lockedDir != "Left")
            {
                foreach (GameObject g in rightWaypoints)
                {
                    if (!trainWayPoints.wp.Contains(g))
                    {
                        trainWayPoints.wp.Add(g);
                    }
                    
                }
                trainWayPoints.SetNextSwitch();

                lockedDir = "Left";



            }
            else if (goLeft && lockedDir != "Right")
            {
                foreach (GameObject g in leftWaypoints)
                {
                    if (!trainWayPoints.wp.Contains(g))
                    {
                        trainWayPoints.wp.Add(g);
                    }
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
                        if (!trainWayPoints.wp.Contains(g))
                        {
                            trainWayPoints.wp.Add(g);
                        }
                    }
                    trainWayPoints.SetNextSwitch();
                }
               else if (goBack)
                {
                    foreach (GameObject g in backWaypoints)
                    {
                        if (!trainWayPoints.wp.Contains(g))
                        {
                            trainWayPoints.wp.Add(g);
                        }
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
                        if (!trainWayPoints.wp.Contains(g))
                        {
                            trainWayPoints.wp.Add(g);
                        }
                    }
                    trainWayPoints.SetNextSwitch();
                }
                else if (goBack)
                {
                    foreach (GameObject g in backWaypoints)
                    {
                        if (!trainWayPoints.wp.Contains(g))
                        {
                            trainWayPoints.wp.Add(g);
                        }
                    }
                    trainWayPoints.SetNextSwitch();

                    lockedDir = "Back";
                }

            }

        }

        }

    void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "Train" || other.transform.tag == "AITrain" || other.transform.tag == "PlayerCart" || other.transform.tag == "AICart")
        {
            trainPassing = false;
        }
    }

    public void CheckWaypointBeforeSwitch()
    {
        if(wpTrainCameFrom != null)
        {
            if (wpTrainCameFrom == backWaypoints[0] && lockedDir != "Back" && !goRight)
            {
                cameFromBack = true;
                
                goLeft = true;
                goRight = false;
                dirText.text = "Left";
                goBack = false;
                lockedDir = "Back";
            }
            else if (wpTrainCameFrom == rightRails[0].GetComponent<Rails>().myWaypoints[1] || wpTrainCameFrom == rightRails[0].GetComponent<Rails>().myWaypoints[0] && lockedDir != "Right" && !goLeft)
            {
                //Figure out reversing
                tren.wp.Remove(gameObject);
                if (!backWRReversed)
                {
                    backWaypointsLRight.Reverse();
                    backWRReversed = true;
                }
                
                foreach(GameObject g in backWaypointsLRight)
                {
                    tren.wp.Add(g);
                }
                tren.nextWp = tren.wp[0];
                tren.wp.Add(gameObject);
              
                tren.SetNextSwitch();
                goBack = true;
                goLeft = false;
                dirText.text = "Back";
                goRight = false;
                lockedDir = "Right";
            }
            else if (wpTrainCameFrom == leftRails[0].GetComponent<Rails>().myWaypoints[1] || wpTrainCameFrom == leftRails[0].GetComponent<Rails>().myWaypoints[0] && lockedDir != "Left" && !goBack)
            {

                tren.wp.Remove(gameObject);
                if (!backWLReversed)
                {
                    backWaypointsLeft.Reverse();
                    backWLReversed = true;
                }

                foreach (GameObject g in backWaypointsLeft)
                {
                    tren.wp.Add(g);
                }
                tren.nextWp = tren.wp[0];
                tren.wp.Add(gameObject);

                tren.SetNextSwitch();

                goRight = false;
                goBack = true;
                dirText.text = "Back";
                goLeft = false;
                lockedDir = "Left";
            }
        }
    }
    }
