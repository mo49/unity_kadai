using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class Recentering : MonoBehaviour {

    private Clicker clicker = new Clicker();
    public bool isInitPosition = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (clicker.clicked())
        {
            isInitPosition = !isInitPosition;
        }
        if (isInitPosition)
        {
            InputTracking.Recenter();
        }
	}

}
