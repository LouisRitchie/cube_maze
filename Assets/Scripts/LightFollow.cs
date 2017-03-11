using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour {
    public float speed =0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.z < 540) { 
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+speed);
        }

    }

    public void setSpeed(float speed) {
        this.speed = speed;
    }
}
