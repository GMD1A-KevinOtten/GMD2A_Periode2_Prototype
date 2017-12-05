using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteSwitch : MonoBehaviour {

    public List<GameObject> rightRails = new List<GameObject>();
    public List<GameObject> leftRails = new List<GameObject>();
    public List<GameObject> backRails = new List<GameObject>();

    public List<GameObject> rightWaypoints = new List<GameObject>();
    public List<GameObject> leftWaypoints = new List<GameObject>();
    public List<GameObject> backWaypoints = new List<GameObject>();

    public List<GameObject> nextSwitches = new List<GameObject>();

    public string lockedDir;
    public bool goLeft;
    public bool goRight;
    public bool goBack;

    private TextMesh dirText;
    public GameObject wpTrainCameFrom;

    public bool trainPassing;

    void Start () {

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
        //UpdateText();

    }

    IEnumerator WaitToLoad()
    {
        yield return new WaitForSeconds(3);
        foreach (GameObject g in rightRails)
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
        //Switches 0 = links 1 = rechts 2 = back
        rightWaypoints.Add(nextSwitches[1]);

        foreach (GameObject g in leftRails)
        {
            if (g.tag != "BigSwitch")
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

        leftWaypoints.Add(nextSwitches[0]);

        foreach (GameObject g in backRails)
        {
            if (g.tag != "BigSwitch")
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

        backWaypoints.Add(nextSwitches[0]);
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
                goLeft = true;
                goRight = false;
                dirText.text = "Left";
                goBack = false;
                lockedDir = "Back";
            }
            else if (wpTrainCameFrom == rightWaypoints[0] && lockedDir != "Right" && !goLeft)
            {
                goBack = true;
                goLeft = false;
                dirText.text = "Back";
                goRight = false;
                lockedDir = "Right";
            }
            else if (wpTrainCameFrom == leftWaypoints[0] && lockedDir != "Left" && !goBack)
            {
                goRight = true;
                goBack = false;
                dirText.text = "Right";
                goLeft = false;
                lockedDir = "Left";
            }
        }
    }
    }
