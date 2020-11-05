using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mathf;

public class Shooting : MonoBehaviour
{

    public GameObject bullet;
    public float velocity;
    public float cd;
    float time;
    public Transform target;
    float shooting_angle;
    public float gravity;

    void Update()
    {
        if (cd < time)
        {
            shooting_angle = Shoot(target);
            time = 0;
        }
        else
            time = time + Time.deltaTime;
    }

    float Shoot(Transform position)
    {
        float angle = 0;

        angle = Atan(velocity * velocity + (Sqrt(velocity * velocity * velocity * velocity - gravity * (gravity * position.position.x * position.position.x + 2 * position.position.y * velocity * velocity))) / gravity * position.position.x);

        return angle;
    }
}
