using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight : MonoBehaviour {
    public Light spotlight;
    public int xrot = 150, yrot = 0, zrot = 100; //initial position of lightbeam
    public float speed = 0.5f;
    public int angle = 20;
    public float waitTime = 0.5f;
    public GameObject player;
    private Vector3 toPlayer;
    public float travelDuration = 10f;

    Quaternion startAngle;
    Quaternion endAngle;

    void Start() {
        startAngle = Quaternion.Euler(xrot,yrot,zrot);
        endAngle = Quaternion.Euler(xrot + Random.Range(-angle, angle), yrot + Random.Range(-angle, angle), zrot + Random.Range(-angle, angle));
        StartCoroutine(searchlight());

    }

    void Update() {      
        if (MELTTFY.seen) {
            toPlayer = (player.transform.position-transform.position).normalized;
            endAngle = Quaternion.LookRotation(toPlayer);

        }
     
    }

    IEnumerator searchlight() {
        float counter = 0;
        //float travelDuration = 10f;
        print("searching for you....");
        while (counter < travelDuration) {

            transform.rotation = Quaternion.Slerp(startAngle, endAngle, counter / travelDuration);
            counter += Time.deltaTime;
            yield return null;
        }
        startAngle = endAngle;
        endAngle = Quaternion.Euler(xrot + Random.Range(-angle, angle), yrot + Random.Range(-angle, angle), zrot + Random.Range(-angle, angle));
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(searchlight());


    }

    public void forgetPlayerPosition() {
        endAngle = Quaternion.Euler(xrot, yrot, zrot);
        print("I forget where you were. Going back to start position...");
    }

    public void setTravelDuration(float duration) {
        travelDuration=duration;
    }

 
}

