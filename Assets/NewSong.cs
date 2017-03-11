using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSong : MonoBehaviour {

 
    public Collider player;
    //public GameObject player;
    public AudioSource epicSong;
    public AudioSource oldSong;
    public GameObject lights;
    public GameObject mELTTFY;

	// Use this for initialization

    void OnTriggerEnter(Collider other) {
        print("colliderd");
        if (other == player) {
            print("song should be playing");
            oldSong.Stop();
            epicSong.Play();
            lights.SetActive(true);
            lights.GetComponent<LightFollow>().setSpeed(0.4f);
            MELTTFY.seen = true;
            mELTTFY.GetComponent<Spotlight>().setTravelDuration(1f);
        }
        }
                
    

	void Start () {
        lights.SetActive(false);

    }

    IEnumerator wait(float time) {
        //stop other song here
        yield return new WaitForSeconds(time);
        epicSong.Play();
    }
	
	// Update is called once per frame
	void Update () {

        }

	}

