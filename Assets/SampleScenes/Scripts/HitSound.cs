using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HitSound : MonoBehaviour, IHitable {

	public AudioClip clip;
	AudioSource audioSrc;

	public void Start() {
		audioSrc = GetComponent<AudioSource> ();
	}

	public void Hit() {
		//audio.PlayOneShot (clip);
		// Debug.Log("Playing");
		audioSrc.PlayOneShot(clip);
	}
}
