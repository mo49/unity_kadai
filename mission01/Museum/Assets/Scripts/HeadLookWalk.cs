using UnityEngine;
using System.Collections;

// 向いている方向に進む
// Physics > CharacterController を追加
public class HeadLookWalk : MonoBehaviour
{
    public float velocity = 0.7f; // 人間の歩く速度1.4m/秒の半分
    public bool isWalking = false;

    private CharacterController controller;
    private Clicker clicker = new Clicker();

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (clicker.clicked())
        {
            isWalking = !isWalking;
        }
        if (isWalking)
        {
            // 向いている方向を与えるだけで、そちらに移動する
            controller.SimpleMove(Camera.main.transform.forward * velocity);
        }
    }
}