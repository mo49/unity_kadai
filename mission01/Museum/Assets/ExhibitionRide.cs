using UnityEngine;
using System.Collections;

// 自動ウォークスルー
public class ExhibitionRide : MonoBehaviour
{
    public GameObject artworks;
    public float startDelay = 3f;
    public float transitionTime = 12.0f; // 作品間の移動時間

    // position.x, position.z, rotation.y
    private AnimationCurve xCurve, zCurve, rCurve;

    // Use this for initialization
    void Start()
    {
        int count = artworks.transform.childCount + 1;
        Keyframe[] xKeys = new Keyframe[count];
        Keyframe[] zKeys = new Keyframe[count];
        Keyframe[] rKeys = new Keyframe[count];
        int i = 0;
        float time = startDelay;
        // 初期位置、初期方向のセット
        // Keyframe(time, value)
        xKeys[0] = new Keyframe(time, transform.position.x);
        zKeys[0] = new Keyframe(time, transform.position.z);
        rKeys[0] = new Keyframe(time, transform.rotation.y);
        foreach (Transform artwork in artworks.transform)
        {
            i++;
            time += transitionTime;
            Vector3 pos = artwork.position - artwork.forward; // 額縁から１ｍ手前の位置 forward = (0,0,1)
            xKeys[i] = new Keyframe(time, pos.x);
            zKeys[i] = new Keyframe(time, pos.z);
            rKeys[i] = new Keyframe(time, artwork.rotation.y);
        }
        // キーフレーム配列からカーブを作成
        xCurve = new AnimationCurve(xKeys);
        zCurve = new AnimationCurve(zKeys);
        rCurve = new AnimationCurve(rKeys);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            xCurve.Evaluate(Time.time),
            transform.position.y,
            zCurve.Evaluate(Time.time));
        Quaternion rot = transform.rotation;
        rot.y = rCurve.Evaluate(Time.time);
        transform.rotation = rot;
    }
}
