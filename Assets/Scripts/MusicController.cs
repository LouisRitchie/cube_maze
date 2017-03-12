using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    public AudioSource epicSong;
    public AudioSource oldSong;
    public static bool shouldPlay;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // if (!oldSong.isPlaying)
        // {
        //  epicSong.Stop();
        //  oldSong.Play();
        //  }

        if (shouldPlay) {
            if (!epicSong.isPlaying) {
                oldSong.Stop();
                epicSong.Play();
            }

        }
        else if (!shouldPlay) {
            if (!oldSong.isPlaying) {
                epicSong.Stop();
                oldSong.Play();
            }
        }
    }
}
