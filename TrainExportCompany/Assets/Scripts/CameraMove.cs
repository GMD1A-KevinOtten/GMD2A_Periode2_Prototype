using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    public float speed;
    public float offset;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
	}

    void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        if(mousePos.x > Screen.width - offset)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        }
        if (mousePos.x < 0 + offset)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        }
        if (mousePos.y < 0 + offset)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
        if (mousePos.y > Screen.height - offset)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }
    }
}
