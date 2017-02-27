using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour {

    public AudioClip BGM;
    public float timer = 5.0f;
    private AudioSource audioSource;

    // Use this for initialization
    IEnumerator Start () {

        enabled = false;
        yield return new WaitForSeconds(timer);
        enabled = true;

        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = BGM;

        audioSource.Play();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
