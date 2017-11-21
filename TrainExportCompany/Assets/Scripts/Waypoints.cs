using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {
    public List<GameObject> wp = new List<GameObject>();
    private bool inRange;
    private int index;

    public float speed;
    public Transform target;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        MoveToWaypoint();
	}

    public void MoveToWaypoint()
    {
        if (inRange == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, wp[index].transform.position, speed * Time.deltaTime);
            target = wp[index].transform;
            Vector3 targetDir = target.position - transform.position;
            Vector3 lookDir = Vector3.RotateTowards(transform.forward, targetDir, speed, 0.0F);
            Quaternion rot = Quaternion.LookRotation(lookDir);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, speed * Time.deltaTime);
            if (index < wp.Count)
            {
                if (transform.position == wp[index].transform.position)
                {
                    index++;
                }
            }
            if (index == wp.Count)
            {
                index = 0;
            }
        }
    }
}
