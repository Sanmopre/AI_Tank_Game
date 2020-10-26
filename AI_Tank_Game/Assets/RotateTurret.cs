using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTurret : MonoBehaviour
{

    public float RotationSpeed;

    public Transform turret;

    //values for internal use
    private Quaternion _lookRotation;
    private Vector3 _direction;

    // Update is called once per frame
    void Update()
    {
        //find the vector pointing from our position to the target
        _direction = (Input.mousePosition - turret.position).normalized;

        //create the rotation we need to be in to look at the target
        _lookRotation = Quaternion.LookRotation(_direction);

        //rotate us over time according to speed until we are in the required rotation
        turret.rotation = Quaternion.Slerp(turret.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
    }
}
