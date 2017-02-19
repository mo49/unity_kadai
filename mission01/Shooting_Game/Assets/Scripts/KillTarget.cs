using UnityEngine;
using System.Collections;

public class KillTarget : MonoBehaviour
{
    public GameObject target;
    public ParticleSystem hitEffect;
    public GameObject killEffect;
    public float timeToSelect = 3.0f;
    public int score;

    private ParticleSystem.EmissionModule hitEffectEmission;
    private float countDown;

    // Use this for initialization
    void Start()
    {
        score = 0;
        countDown = timeToSelect;
        hitEffectEmission = hitEffect.emission;
        hitEffectEmission.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject == target))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            if (countDown > 0.0f)
            {
                // 的中した際の処理
                countDown -= Time.deltaTime;
                hitEffect.transform.position = hit.point;
                hitEffectEmission.enabled = true;
            }
            else
            {
                // 殺された際（カウントが０）の処理
                Instantiate(killEffect, target.transform.position,
                    target.transform.rotation);
                score += 1;
                countDown = timeToSelect;
                SetRandomPosition(); // リポップ
            }
        }
        else
        {
            // リセットする
            countDown = timeToSelect;
            hitEffectEmission.enabled = false;
        }
    }

    // ランダムな場所に移動（リポップ respawn）
    void SetRandomPosition()
    {
        float x = Random.Range(-100.0f, 100.0f);
        float z = Random.Range(-100.0f, 100.0f);
        target.transform.position = new Vector3(x, 0.0f, z);
    }
}
