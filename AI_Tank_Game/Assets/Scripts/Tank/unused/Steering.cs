using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour
{
    float turnSpeed;
    float movSpeed;
    private Vector3 movement;

    public int stopDistance;
    public float turnAcceleration;
    public float maxTurnSpeed; 
    public float acceleration;
    public float maxSpeed;

    private Quaternion rotation;

    public bool Steere(Vector3 target)
    {
        if (Vector3.Distance(target, transform.position) <= stopDistance) 
            return true;

        Seek(acceleration, target);
        
        turnSpeed += turnAcceleration * Time.deltaTime;
        turnSpeed = Mathf.Min(turnSpeed, maxTurnSpeed);
        movSpeed += acceleration * Time.deltaTime;
        movSpeed = Mathf.Min(movSpeed, maxSpeed);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);
        transform.position += transform.forward.normalized * movSpeed * Time.deltaTime;

        return false;
    }

    void Seek(float acceleration, Vector3 target) 
    {
        Vector3 direction = target - transform.position;
        direction.y = 0f;

        movement = direction.normalized * acceleration;

        float angle = Mathf.Rad2Deg * Mathf.Atan2(movement.x, movement.z);
        rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}
