using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsNew : MonoBehaviour {
    public List<GameObject> wp = new List<GameObject>();

    public float speed;

    private GameObject nextWp;
	// Use this for initialization
	void Start () {
		
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
            if(transform.position == nextWp.transform.position)
            {
                wp.Remove(nextWp);
                nextWp = null;
            }
        }
    }
}
