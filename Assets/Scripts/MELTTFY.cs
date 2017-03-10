using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MELTTFY : MonoBehaviour {
    private bool beenSeen = false;


    void OnTriggerEnter(Collider interactor) {
        if (interactor.tag == "Player") {
            print("YOU BEEN SEEN, HOLY FUCK GET GOOD YOU PIECE OF SHIT!");
            Time.timeScale = 0;
        }
    }

}
