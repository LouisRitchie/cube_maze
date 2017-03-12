using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Losing : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision) {

        if(collision.gameObject.name == "player") {
            print("ouch they got ya");
            SceneManager.LoadScene("Game Over");
        }

    } 
}
