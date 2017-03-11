using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MELTTFY : MonoBehaviour {
    private bool beenSeen = false;
    private bool readyOrNot = false;
    public static bool seen = false;

    void Start() {
        StartCoroutine(delayStartTime());
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
        }
    }

    IEnumerator delayStartTime() {
        yield return new WaitForSeconds(2);
        print("Search Started");
        readyOrNot=true;
    }

}
