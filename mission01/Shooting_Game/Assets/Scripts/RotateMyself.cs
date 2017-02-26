using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMyself : MonoBehaviour {

    public float speed = 0.05f;
    public float timer = 15.0f;
    private float count;
    bool isOP = true;

    // Use this for initialization
    void Start () {
        Invoke("Stop", timer);
	}
	
	// Update is called once per frame
	void Update () {
        if (!isOP) return;
        transform.Rotate(0, speed * count, 0, Space.World);
        count += Time.deltaTime;
    }

    void Stop()
    {
        isOP = false;
    }
}
