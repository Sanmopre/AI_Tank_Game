using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class TankStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public GameObject explosion;

    bool stunned = false;

    float landingY;
    Vector3 pos;
    Vector3 vel;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject, 0.0f);
        }

        if (stunned)
        {
            vel.y += -20.0f * Time.deltaTime;
            pos.y += vel.y * Time.deltaTime;

            if(pos.y < landingY)
                stunned = false;

            transform.position = pos;
        }
    }

    public void Damage()
    {
        health--;

        stunned = true;
        pos = transform.position;
        landingY = pos.y;
        vel = Vector3.up * 10;
    }
}
