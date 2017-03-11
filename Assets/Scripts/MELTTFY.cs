using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MELTTFY : MonoBehaviour {
    private bool beenSeen = false;
    private bool readyOrNot = false;
    public static bool seen = false;
    public float radius = 45;
    public Spotlight spot;

    void Start() {
        StartCoroutine(delayStartTime());
    }

    void Update() {
       /* RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward,Color.cyan);
        if (Physics.SphereCast(transform.position, radius, transform.forward , out hit)) {
            print(hit.collider.tag);
            if(hit.collider.tag == "Player") {
                print("YOU BEEN SEEN, HOLY FUCK GET GOOD YOU PIECE OF SHIT!");
            }

        }*/

    }




    void OnTriggerEnter(Collider interactor) {
        if (interactor.tag == "Player" && readyOrNot) {
            print("YOU BEEN SEEN, HOLY FUCK GET GOOD YOU PIECE OF SHIT!");
            seen = true;
        }
    }

    void OnTriggerExit(Collider interactor) {
        if (interactor.tag == "Player" && readyOrNot) {
            print("Ahh, the bliss of darkness...");
            seen = false;
            spot.forgetPlayerPosition();
            
        }
    }

    IEnumerator delayStartTime() {
        yield return new WaitForSeconds(2);
        print("Search Started");
        readyOrNot=true;
    }

}
