using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsNew : MonoBehaviour {
    public List<GameObject> wp = new List<GameObject>();

    public float speed;

    private GameObject nextWp;
    public GameObject nextSwitch;

    public float speedAtStop;
    private bool waiting;

    // Use this for initialization
    void Start () {
        SetNextSwitch();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        MoveToWaypoint();
	}

    void MoveToWaypoint()
    {
        if(nextWp != null)
        {
            Vector3 targetDir = nextWp.transform.position - transform.position;
            Vector3 lookDir = Vector3.RotateTowards(transform.forward, targetDir, speed, 0.0F);
            Quaternion rot = Quaternion.LookRotation(lookDir);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, speed * Time.deltaTime);

        }
        for (int i = 0; i < wp.Count; i++)
        {
            if (nextWp == null)
            {
                nextWp = wp[i];
            }
        }
           
        

        if(nextWp != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextWp.transform.position, speed * Time.deltaTime);
            if(nextSwitch != null)
            {
                if(nextWp != nextSwitch)
                {
                    RouteSwitch r = nextSwitch.GetComponent<RouteSwitch>();
                    if(r != null)
                    {
                        r.wpTrainCameFrom = nextWp;
                    }
                }
                if(nextWp == nextSwitch && nextSwitch != null)
                {
                    RouteSwitch r = nextSwitch.GetComponent<RouteSwitch>();
                    if(r != null)
                    {
                        if (r.trainPassing && transform.tag == "AITrain")
                        {
                            speedAtStop = 2;
                            GetComponent<Train>().speed = 0;
                        }
                        else if (!r.trainPassing && transform.tag == "AITrain" && GetComponent<Train>().speed <= 0 )
                        {
                            if (!waiting)
                            {
                                StartCoroutine(Wait());
                                waiting = true;
                            }
                       
                        }

                    }
                    if (r != null)
                    {
                        r.CheckWaypointBeforeSwitch();
                        r = null;
                    }
                }

            }
            if(transform.position == nextWp.transform.position)
            {
                wp.Remove(nextWp);
                nextWp = null;
            }
        }
    }

    public void SetNextSwitch()
    {
        nextSwitch = wp[wp.Count -1];
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        GetComponent<Train>().speed = speedAtStop;
        waiting = false;
    }
}
