using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traincart : MonoBehaviour {
    public List<GameObject> wp = new List<GameObject>();
    private GameObject nextWp;
    private Train train;

    public bool aiCart;
    public Train trainToFollow;
    void Start()
    {
        if(transform.tag == "PlayerCart")
        {
            train = GameObject.FindGameObjectWithTag("Train").GetComponent<Train>();
        }
        else if(aiCart && transform.tag != "PlayerCart")
        {
            train = trainToFollow;
        }
        nextWp = wp[0];
        
    }

    void Update()
    {
        if(nextWp == null)
        {

           
            foreach(Transform child in train.trainCarts[train.trainCarts.IndexOf(gameObject) - 1].transform)
            {
                if (child.tag == "FollowCart")
                {
                    wp[0] = child.gameObject;
                }
            }
            nextWp = wp[0];
        }
        if (nextWp != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextWp.transform.position, train.speed  * Time.deltaTime);

            Vector3 targetDir = nextWp.transform.position - transform.position;
            Vector3 lookDir = Vector3.RotateTowards(transform.forward, targetDir, train.speed * 6000, 0.0F);
            Quaternion rot = Quaternion.LookRotation(lookDir);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, train.speed * 6000 * Time.deltaTime);

        }
    }
}
