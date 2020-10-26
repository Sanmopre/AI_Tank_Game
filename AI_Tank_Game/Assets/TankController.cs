using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TankInputs))]
public class TankController : MonoBehaviour
{

    private Rigidbody rb;
    private TankInputs input;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        input = GetComponent<TankInputs>();
    }


    void Update()
    {
        
    }
}
