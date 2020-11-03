using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour
{

    public GameObject target;
    public int stopDistance;

    float turnSpeed;
    float movSpeed;
    public Vector3 movement;

    public float turnAcceleration;
    public float maxTurnSpeed;
    public float acceleration;
    public float maxSpeed;
    public Quaternion rotation;

    void Update()
    {
        if (Vector3.Distance(target.transform.position, transform.position) <
    stopDistance) return;
        Seek();   // calls to this function should be reduced
        turnSpeed += turnAcceleration * Time.deltaTime;
        turnSpeed = Mathf.Min(turnSpeed, maxTurnSpeed);
        movSpeed += acceleration * Time.deltaTime;
        movSpeed = Mathf.Min(movSpeed, maxSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation,
                                              rotation, Time.deltaTime * turnSpeed);
        transform.position += transform.forward.normalized * movSpeed *
                              Time.deltaTime;
    }

    void Seek() {
        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0f;
        movement = direction.normalized * acceleration;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(movement.x, movement.z);
        rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}
