using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight : MonoBehaviour {
    public Light spotlight;
    public int xrot = 115, yrot = 83, zrot = 161;
    // Use this for initialization
    public Transform startMarker;
    public Transform endMarker;
    public float speed = 0.1f;
    private float startTime;
    private float journeyLength;
    Quaternion startAngle;
    Quaternion endAngle;

    void Start() {
        startAngle = Quaternion.Euler(xrot,yrot,zrot);
        endAngle = Quaternion.Euler(xrot + Random.Range(-10, 10), yrot + Random.Range(-10, 10), zrot + Random.Range(-10, 10));

    }
    void Update() {
        spotlight.transform.rotation = Quaternion.Slerp(startAngle,endAngle,Time.time*speed);
        startAngle = endAngle;
        endAngle = Quaternion.Euler(xrot + Random.Range(-10, 10), yrot + Random.Range(-10, 10), zrot + Random.Range(-10, 10));
    }
}

