using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform target;
    public Transform cannon;

    public GameObject bullet;

    public int range;

    public float fireRate;
    float fireTimer;

    private void Start()
    {
        fireTimer = 0.0f;
    }

    private void Update()
    {
        cannon.transform.LookAt(target);

        if (Vector3.Distance(target.position, transform.position) <= range)
        {
            if(fireTimer >= fireRate)
            {
                fireTimer = 0.0f;

                Homing homing = Instantiate(bullet, cannon.position, cannon.rotation).GetComponent<Homing>();
                homing.SetTarget(target.gameObject);
            }
            fireTimer += Time.deltaTime;

            return;
        }
        fireTimer = 0.0f;
    }

}
