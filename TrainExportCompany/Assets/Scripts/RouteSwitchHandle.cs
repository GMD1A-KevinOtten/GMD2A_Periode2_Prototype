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

        if (parentSwitch.goLeft && parentSwitch.lockedDir != "Left")
        {
            dirText.text = "Left";
        }
        else if (!parentSwitch.goRight && parentSwitch.lockedDir != "Right")
        {
            dirText.text = "Right";
        }
        else if (parentSwitch.goBack && parentSwitch.lockedDir != "Back")
        {
            dirText.text = "Back";
        }
    }
	
	// Update is called once per frame
	void Update () {
       
	}

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!parentSwitch.goLeft && parentSwitch.lockedDir != "Left")
            {
                parentSwitch.goLeft = true;
                parentSwitch.goRight = false;
                parentSwitch.goBack = false;
                dirText.text = "Left";
            }
            else if (!parentSwitch.goRight && parentSwitch.lockedDir != "Right")
            {
                parentSwitch.goRight = true;
                parentSwitch.goLeft = false;
                parentSwitch.goBack = false;
                dirText.text = "Right";
            }
            else if(!parentSwitch.goBack && parentSwitch.lockedDir != "Back" && parentSwitch.lockedDir == "Left" || parentSwitch.lockedDir == "Right")
            {
                parentSwitch.goRight = false;
                parentSwitch.goLeft = false;
                parentSwitch.goBack = true;
                dirText.text = "Back";
            }
        }
    }
}
