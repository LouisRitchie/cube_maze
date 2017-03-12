using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NavigationScript_Ball : MonoBehaviour {
    //The navigation AI tutorial I was watching: https://www.youtube.com/watch?v=akzsUN4yy1k
    public GameObject playerPos;
    public RaycastHit hit;
    public RaycastHit chasing;
    private Vector3 startPos;
    private Quaternion startRot;
    public GameObject eyeLight;
   // public AudioSource epicSong;
    //public AudioSource oldSong;
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
        if (Physics.SphereCast(transform.position, 2f, transform.forward, out hit)) {
            if (hit.collider.gameObject.tag == "Player") {
                wasSeen = true;
            }
        }

        if (wasSeen)
        {
            rayCastDirection = playerPos.transform.position - transform.position;
            if (Physics.Raycast(transform.position, rayCastDirection, out chasing))
            {
                if (chasing.collider.gameObject.tag == "Player")
                {
                    gameObject.GetComponent<NavMeshAgent>().SetDestination(playerPos.transform.position);
                    eyeLight.SetActive(true);
                    MusicController.shouldPlay=true;
                  //  if (!epicSong.isPlaying)
                  //  {
                  //      oldSong.Stop();
                  //      epicSong.Play();
                  //  }
                }
                if (chasing.collider.gameObject.tag != "Player" && !MELTTFY.seen)
                {
                    gameObject.GetComponent<NavMeshAgent>().SetDestination(startPos);
                    transform.rotation = startRot;
                    rayCastDirection = transform.forward;
                    eyeLight.SetActive(false);
                    // if (!oldSong.isPlaying)
                    // {
                    //  epicSong.Stop();
                    //  oldSong.Play();
                    //  }
                    MusicController.shouldPlay=false;
                    wasSeen = false;
                }
            }
        }
        else
        {
            //Makes the robot spin about the y axis.
            transform.Rotate(0, (float) 0.5, 0); 
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
