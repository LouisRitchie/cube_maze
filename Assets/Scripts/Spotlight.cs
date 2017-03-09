﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight : MonoBehaviour {
    public Light spotlight;
    public int xrot = 150, yrot = 0, zrot = 100; //initial position of lightbeam
    public float speed = 0.5f;
    public float waitTime = 0;

    Quaternion startAngle;
    Quaternion endAngle;

    void Start() {
        startAngle = Quaternion.Euler(xrot,yrot,zrot);
        endAngle = Quaternion.Euler(xrot + Random.Range(-10, 10), yrot + Random.Range(-10, 10), zrot + Random.Range(-10, 10));
        StartCoroutine(searchlight());

    }

    void Update() {
        //StartCoroutine(searchlight());
     
    }

    IEnumerator searchlight() {
        float counter = 0;
        float travelDuration = 2f;
        while (counter < travelDuration) {

            transform.rotation = Quaternion.Slerp(startAngle, endAngle, counter / travelDuration);
            counter += Time.deltaTime;
            yield return null;
        }
        startAngle = endAngle;
        endAngle = Quaternion.Euler(xrot + Random.Range(-10, 10), yrot + Random.Range(-10, 10), zrot + Random.Range(-10, 10));
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(searchlight());


    }
}
