using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Wandering : MonoBehaviour
{
    public NavMeshAgent agent;
    Vector3 target;

    public int radius;

    // Start is called before the first frame update
    void Start()
    {
        Retarget();
    }

    // Update is called once per frame
    void Update()
    {
        float d = Vector3.Distance(target, transform.position);
        if (Vector3.Distance(target, transform.position) <= agent.stoppingDistance + 1)
            Retarget();
    }

    void Retarget()
    {
        int x = Random.Range(-radius, radius);
        int z = Random.Range(-radius, radius);
        target.x = x;
        target.y = 0.0f;
        target.z = z;

        agent.destination = target;
    }
}
