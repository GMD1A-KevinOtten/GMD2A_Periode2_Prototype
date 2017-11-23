using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteSwitchHandle : MonoBehaviour {
    private RouteSwitch parentSwitch;
	// Use this for initialization
	void Start () {
        parentSwitch = GetComponentInParent<RouteSwitch>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (parentSwitch.turnRight)
            {
                parentSwitch.turnRight = false;
            }
            else if (!parentSwitch.turnRight)
            {
                parentSwitch.turnRight = true;
            }
        }
    }
}
