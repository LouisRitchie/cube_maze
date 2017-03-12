using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    public GameObject door;
	// Use this for initialization
	void Start () {
        door.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (MELTTFY.seen) {
            door.SetActive(true);
        }
        else if (!MELTTFY.seen) {
            door.SetActive(false);
        }
	}
}
