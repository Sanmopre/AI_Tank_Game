using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class TankStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public GameObject explosion;
    public GameObject h1;
    public GameObject h2;
    public GameObject h3;

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
        HealthUI();

        if (health == 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            gameObject.SetActive(false);

            stunned = false;

            return;
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

    public void Reset()
    {
        stunned = false;
        health = 3;
    }

    private void HealthUI()
    {
        h1.SetActive(false);
        h2.SetActive(false);
        h3.SetActive(false);
        if (health >= 1)
        {
            h1.SetActive(true);
            if (health >= 2)
            {
                h2.SetActive(true);
                if (health == 3)
                {
                    h3.SetActive(true);
                }
            }
        }
    }
}
