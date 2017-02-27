using UnityEngine;
using System.Collections;

public class HeadLookWalkBounce : MonoBehaviour
{
    public float velocity = 0.7f;
    public bool walking = false;

    public float gravity = 9.8f;
    public float bounceForce = 0.0f;
    public float forceFactor = 0.02f;

    private CharacterController controller;

    private float verticalVelocity = 0.0f;
    private Vector3 moveDirection = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Vector3.zero;
        if (controller.isGrounded)
        { // 地面の上では加速度０
            verticalVelocity = 0.0f;
        }
        if (bounceForce != 0.0f)
        {
            verticalVelocity = bounceForce * forceFactor;
            bounceForce = 0.0f;
        }
        moveDirection.y = verticalVelocity;
        verticalVelocity -= gravity * Time.deltaTime;
        // SimpleMoveはy軸を無視していたのでここでは使わない
        controller.Move(moveDirection * Time.deltaTime);
    }
}
