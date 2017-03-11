using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour {
    public Vector3 vector = new Vector3(-1200, 50, 700);
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        transform.RotateAround(vector, Vector3.up, 30 * Time.deltaTime);
    }
}
