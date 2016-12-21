using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {
	public AudioClip[] soundtrack;
	private AudioSource source;

	// Use this for initialization
	// gives acces to audio component
	//starts a random song on start
	void Start () {
		source = GetComponent<AudioSource> ();

		if (!source.isPlaying) {
			source.clip = soundtrack[Random.Range(0, soundtrack.Length)];
			source.Play();
		}
	}

	// Update is called once per frame
	// if there is no audio playing, pick a random song and play
	void Update () {

		if (!source.isPlaying) {
			source.clip = soundtrack[Random.Range(0, soundtrack.Length)];
			source.Play();
		}
	}
}