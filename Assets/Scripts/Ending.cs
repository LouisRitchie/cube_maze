﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour {
    private bool isAtEnd = false;

    
    void OnTriggerEnter(Collider interactor) {
        print("collided");
        if (interactor.tag == "Player") {
            print("press E");
            isAtEnd=true;
        }
    }

    void OnTriggerExit(Collider interactor) {
        if (interactor.tag == "Player") {
            isAtEnd=false;
            print("not close enough");
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (isAtEnd) {
                Time.timeScale = 0;
                print("You win you frekkin nerd!");
                }

        }


    }




}
