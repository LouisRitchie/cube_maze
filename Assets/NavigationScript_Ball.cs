using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//NavigationScript_Ball:
//  Currently: if the ball "spots" the player via raycast (double check that it actually
//  does a comprehensive scan and not just wherever the object is facing.
//
//TODO (mandatory): in PlayerSpotted(), make sure the tag that it's checking for is the one
//                  the player is associated with.
//
//TODO: (optional): -replace else case in update() with some sort of random crawling behaviour.
//                  -check if raycast does comprehensive scan.
//                  -Fix the camera/raycast situation so that the camera will point at the player
//                  as soon as it is spotted and also not roll with the ball
public class NavigationScript_Ball : MonoBehaviour {
    //The navigation AI tutorial I was watching: https://www.youtube.com/watch?v=akzsUN4yy1k
    public GameObject target;
    //public RaycastHit hit;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        //if (PlayerSpotted()) {
            gameObject.GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
        //}
        /* else
        {
            //TODO: replace following the ball has stopped and is aimlessly rolling into a 
            //stopped behaviour with random crawling?

            //Currently, this script just makes the ball roll to one direction constantly.
            //gameObject.GetComponent<NavMeshAgent>().SetDestination(Vector3.zero);
        }
        */
	}

    /*
    bool PlayerSpotted() {
        bool condition1 = Physics.Raycast(transform.position, transform.forward, out hit);
        bool condition2 = hit.collider.gameObject.tag == "Player";
        print("Warning: \"Player\" tag in PlayerSpotted() in NavigationScript_Ball.cs not implemented.");
        return condition1 && condition2;
    }
    */
}
