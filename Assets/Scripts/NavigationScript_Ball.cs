using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*  NavigationScript_Ball:
 *      Currently: makes the associated entity traverse a navmesh toward the GameObject "target"
 *      
 *      Lines tagged with "*****" can be uncommented in order to make a raycast trigger this
 *      behaviour.
*/
public class NavigationScript_Ball : MonoBehaviour {
    //The navigation AI tutorial I was watching: https://www.youtube.com/watch?v=akzsUN4yy1k
    public GameObject playerPos;
    public RaycastHit hit;
    public RaycastHit chasing;
    private Vector3 startPos;
    private Quaternion startRot;
    public GameObject eyeLight;
    public AudioSource epicSong;
    public AudioSource oldSong;
    private Vector3 rayCastDirection;
    bool wasSeen = false;

    // Use this for initialization
    void Start () {
        startPos = transform.position;
        startRot = transform.rotation;
        eyeLight.SetActive(false);
        rayCastDirection=transform.forward;
	}

    // Update is called once per frame
    void Update() {
        //The current problem with this condition seems to be the sphere moving in such a way
        //that the camera (meaning the raycast as well) captures the wrong field of view.
        //Changing the behaviour of the camera to something like an X-Z plane rotation should fix this.
        if (Physics.SphereCast(transform.position, 2f, transform.forward, out hit)) {
            if (hit.collider.gameObject.tag == "Player") {
                wasSeen = true;
            }
        }

        if (wasSeen) {
            rayCastDirection  = playerPos.transform.position - transform.position;
            if (Physics.Raycast(transform.position, rayCastDirection, out chasing)) {
                if (chasing.collider.gameObject.tag == "Player") {
                    gameObject.GetComponent<NavMeshAgent>().SetDestination(playerPos.transform.position);
                    eyeLight.SetActive(true);
                    oldSong.Stop();
                    epicSong.Play();
                }
                if (chasing.collider.gameObject.tag != "Player" && !MELTTFY.seen) {
                    gameObject.GetComponent<NavMeshAgent>().SetDestination(startPos);
                    transform.rotation =startRot;
                    rayCastDirection = transform.forward;
                    eyeLight.SetActive(false);
                    epicSong.Stop();
                    oldSong.Play();
                    wasSeen = false;
                }
            }
            //*****
            /* else
            {
                //TODO: replace following the ball has stopped and is aimlessly rolling into a 
                //stopped behaviour with random crawling?

                //Currently, this script just makes the ball roll to one direction constantly.
                //The Vector3.zero vector is probably the problem.
                //gameObject.GetComponent<NavMeshAgent>().SetDestination(Vector3.zero);
            }
            */
        }
    }

    void OnTriggerStay(Collider other) {
        if(other.tag == "Player" && MELTTFY.seen) {
            gameObject.GetComponent<NavMeshAgent>().SetDestination(playerPos.transform.position);
           // transform.forward = playerPos.transform.position - transform.position;
            eyeLight.SetActive(true);
        }
    }
 
   // void PlayerSpotted() {

        
     //   Debug.DrawRay(transform.position, rayCastDirection, Color.red );
    
        // bool condition2 = hit.collider.gameObject.tag == "Player";
        //print("Warning: \"Player\" tag in PlayerSpotted() in NavigationScript_Ball.cs not implemented.");
         //&& condition2;
  //  }
   
}
