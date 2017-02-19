using UnityEngine;
using System.Collections;

public class RandomPosition : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine(RePositionWithDelay());
        //RePositionWithDelay();
    }

    IEnumerator RePositionWithDelay()
    {
        while (true)
        {
            SetRandomPosition();
            // コルーチンを遅延させてから再開させる
            yield return new WaitForSeconds(10);
        }
    }

    void SetRandomPosition()
    {
        float x = Random.Range(-100.0f, 100.0f);
        float z = Random.Range(-100.0f, 100.0f);
        Debug.Log("x,z: " + x.ToString("F2") + ", " + z.ToString("F2"));
        transform.position = new Vector3(x, 0.0f, z);
    }

    // Update is called once per frame
    void Update()
    {

    }

}