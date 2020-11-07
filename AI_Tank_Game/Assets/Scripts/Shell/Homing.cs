using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    public int speed;

    float gravity = -20.0f;
    float distance;

    Vector3 target;
    bool targeting = false;

    Vector3 pos;
    Vector3 vel;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;

        Vector3 toTarget = (target - pos);
        toTarget.y = 0.0f;
        distance = toTarget.magnitude;

        vel = toTarget.normalized * speed;
        float vox = (new Vector2(vel.x, vel.z)).magnitude;

        vel.y = -gravity * distance / (2 * vox);
    }

    // Update is called once per frame
    void Update()
    {
        if (!targeting)
            return;

        vel.y += gravity * Time.deltaTime;

        pos.x += vel.x * Time.deltaTime;
        pos.y += vel.y * Time.deltaTime;
        pos.z += vel.z * Time.deltaTime;

        transform.forward = vel;

        if (pos.y <= 0.0f)
            Destroy(gameObject, 0.0f);

        transform.position = pos;
    }

    public void SetTarget(GameObject tar)
    {
        target = tar.transform.position + tar.transform.forward.normalized * 5;
        targeting = true;
    }
}
