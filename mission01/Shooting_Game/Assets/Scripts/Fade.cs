using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public float alpha;
    public float speed = 0.005f;
    public float timer = 10.0f;
    public bool isFadeIn = false;
    float red, green, blue;

    IEnumerator Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        enabled = false;
        yield return new WaitForSeconds(timer);
        enabled = true;
    }

    void Update()
    {
        GetComponent<Image>().color = new Color(red, green, blue, alpha);
        if (isFadeIn)
        {
            alpha += speed;
        } else {
            alpha -= speed;
        }
        
    }

}