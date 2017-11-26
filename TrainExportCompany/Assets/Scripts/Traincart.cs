using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traincart : MonoBehaviour {
    

    //WERKT NOG NIET


    //private GameObject train;
    //private GameObject cartInFront;
    //private Train trainScript;
	// Use this for initialization
	void Start () {
        //train = GameObject.FindGameObjectWithTag("Train");
        //trainScript = train.GetComponent<Train>();

        //cartInFront = trainScript.trainCarts[trainScript.trainCarts.IndexOf(gameObject) -1];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
	}

    void Move()
    {
        //Vector3 v = new Vector3(cartInFront.transform.position.x - trainScript.cartOffset, cartInFront.transform.position.y, cartInFront.transform.position.z);

        //transform.position = Vector3.MoveTowards(transform.position, v, trainScript.speed * Time.deltaTime);

        //Vector3 targetDir = cartInFront.transform.position - transform.position;
        //Vector3 lookDir = Vector3.RotateTowards(transform.forward, targetDir, trainScript.speed, 0.0F);
        //Quaternion rot = Quaternion.LookRotation(lookDir);
        //transform.rotation = Quaternion.Lerp(transform.rotation, rot, trainScript.speed * Time.deltaTime);
    }
}
