using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon_Aim : MonoBehaviour
{
    public Transform target;
    public Transform cannon;

    private void Update()
    {
        Vector3 targetPostition = new Vector3(target.position.x,
                                               cannon.transform.position.y,
                                               target.position.z);
        cannon.transform.LookAt(targetPostition);
    }

}
