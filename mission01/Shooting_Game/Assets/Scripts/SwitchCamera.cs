using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour {

    private GameObject MainCam;
    private GameObject SubCam;
    public float timer = 10.0f;

    IEnumerator Start()
    {
        MainCam = GameObject.Find("Main Camera");
        SubCam = GameObject.Find("Sub Camera");

        MainCam.SetActive(false);

        enabled = false;
        yield return new WaitForSeconds(timer);
        enabled = true;

        Change();

    }
    
    /*
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (MainCam.activeSelf)
            {
                MainCam.SetActive(false);
                SubCam.SetActive(true);
            }
            else
            {
                MainCam.SetActive(true);
                SubCam.SetActive(false);
            }
        }
    }
    */

    void Update()
    {
       
    }

    void Change()
    {
        MainCam.SetActive(true);
        SubCam.SetActive(false);
    }

}
