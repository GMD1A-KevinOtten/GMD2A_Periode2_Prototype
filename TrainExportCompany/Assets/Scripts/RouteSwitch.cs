using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteSwitch : MonoBehaviour {
    public bool turnRight;
    public GameObject nextSwitch;

    public List<GameObject> rightWaypoints = new List<GameObject>();
    public List<GameObject> leftWaypoints = new List<GameObject>();

    //public List<GameObject> whereTrainCameFrom = new List<GameObject>();

    //public bool trainPassedOneTime;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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

            if (turnRight)
            {
                foreach(GameObject g in rightWaypoints)
                {
                    trainWayPoints.wp.Add(g);
                }
                //trainPassedOneTime = true;
            }
            else if (!turnRight)
            {
                foreach (GameObject g in leftWaypoints)
                {
                    trainWayPoints.wp.Add(g);
                }
                //trainPassedOneTime = true;
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
