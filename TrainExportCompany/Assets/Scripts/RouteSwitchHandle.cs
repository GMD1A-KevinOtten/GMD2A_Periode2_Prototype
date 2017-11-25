using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RouteSwitchHandle : MonoBehaviour {
    private RouteSwitch parentSwitch;

    private TextMesh dirText;
	// Use this for initialization
	void Start () {
        parentSwitch = GetComponentInParent<RouteSwitch>();
        dirText = GetComponentInChildren<TextMesh>();
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
                dirText.text = "Left";
            }
            else if (!parentSwitch.turnRight)
            {
                parentSwitch.turnRight = true;
                dirText.text = "Right";
            }
            //else if (parentSwitch.turnedRightLastTime)
            //{
                
            //    dirText.text = "Left";
            //}
            //else if (!parentSwitch.turnedRightLastTime)
            //{

            //    dirText.text = "Right";
            //}
        }
    }
}
