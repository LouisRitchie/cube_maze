using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSong : MonoBehaviour {

 
    public Collider player;
    //public GameObject player;
    public AudioSource epicSong;
    public AudioSource oldSong;

	// Use this for initialization

    void OnTriggerEnter(Collider other) {
        print("colliderd");
        if (other == player) {
            print("song should be playing");
            oldSong.Stop();
            epicSong.Play();          
            }
        }
                
    

	void Start () {
		
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

