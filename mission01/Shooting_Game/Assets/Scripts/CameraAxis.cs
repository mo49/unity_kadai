using UnityEngine;
using System.Collections;

public class CameraAxis : MonoBehaviour
{
    public float fRotateSpeed = 10.0f;

    void Update()
    {
        // 左
        bool canRotateLeft = Input.GetMouseButton(0);
        // 右
        bool canRotateRight = Input.GetMouseButton(1);
        // 中
        bool canResetPos = Input.GetMouseButton(2);

        if (canRotateLeft)
        {
            // 移動量 
            float fValue = fRotateSpeed * Time.deltaTime;
            // 回転 
            transform.Rotate(0, -fValue, 0, Space.World);
        }
        if (canRotateRight)
        {
            float fValue = fRotateSpeed * Time.deltaTime;
            transform.Rotate(0, fValue, 0, Space.World);
        }
        if (canResetPos)
        {
            transform.localRotation = Quaternion.identity;
        }
    }
}

// http://tasogare-games.hatenablog.jp/entry/20150607/1433680283