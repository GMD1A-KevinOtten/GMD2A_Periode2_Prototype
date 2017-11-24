using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteSwitch : MonoBehaviour {
    public bool turnRight;
    public GameObject nextSwitch;

    public bool turnedRightLastTime;
    public bool trainPassedOnce;

    public List<GameObject> rightWaypoints = new List<GameObject>();
    public List<GameObject> leftWaypoints = new List<GameObject>();

    private TextMesh dirText;

    //public List<GameObject> whereTrainCameFrom = new List<GameObject>();

    //public bool trainPassedOneTime;
    // Use this for initialization
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
        UpdateText();

    }

    void UpdateText()
    {
        if (turnedRightLastTime)
        {
            dirText.text = "Left";
        }
        else if (!turnedRightLastTime)
        {
            dirText.text = "Right";
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if(other.transform.tag == "Train")
        {
            Waypoints trainWayPoints = other.GetComponent<Waypoints>();



            //foreach(GameObject g in trainWayPoints.wp)
            //{
            //    whereTrainCameFrom.Add(g);
            //}

            //if (!trainPassedOneTime)
            //{
            //    for (int i = 0; i < trainWayPoints.wp.Count; i++)
            //    {
            //        trainWayPoints.wp.RemoveAt(i);
            //    }

            //}
           
            foreach (GameObject g in trainWayPoints.wp)
            {
                trainWayPoints.wp.Remove(g);
            }
            trainWayPoints.index = 0;
            

            if (turnRight && !trainPassedOnce)
            {
                foreach(GameObject g in rightWaypoints)
                {
                    trainWayPoints.wp.Add(g);
                }
                turnedRightLastTime = true;
               
                trainPassedOnce = true;
            }
            else if (!turnRight && !trainPassedOnce)
            {
                foreach (GameObject g in leftWaypoints)
                {
                    trainWayPoints.wp.Add(g);
                }
                turnedRightLastTime = false;
                
                trainPassedOnce = true;
            }
            else if(trainPassedOnce && turnedRightLastTime)
            {
                foreach (GameObject g in leftWaypoints)
                {
                    trainWayPoints.wp.Add(g);
                }

                turnedRightLastTime = false;
                trainPassedOnce = true;
            }
            else if (trainPassedOnce && !turnedRightLastTime)
            {
                foreach (GameObject g in rightWaypoints)
                {
                    trainWayPoints.wp.Add(g);
                }
                turnedRightLastTime = true;
                trainPassedOnce = true;
            }
            //        else if (trainPassedOneTime)
            //        {


            //            GameObject[] temp = whereTrainCameFrom.ToArray();
            //            System.Array.Reverse(temp);

            //            for (int i = 0; i < whereTrainCameFrom.Count; i++)
            //            {
            //                whereTrainCameFrom.RemoveAt(i);
            //            }

            //            foreach(GameObject g in temp)
            //            {
            //                whereTrainCameFrom.Add(g);
            //            }

            //            foreach (GameObject g in whereTrainCameFrom)
            //            {

            //                trainWayPoints.wp.Add(g);


            //            }
            //            trainWayPoints.wp.Remove(gameObject);
            //            trainWayPoints.wp.Add(nextSwitch);
            //            trainPassedOneTime = false;
            //        }
        }
        }
    }
