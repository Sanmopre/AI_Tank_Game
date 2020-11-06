using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Patroling : MonoBehaviour
{
    public NavMeshAgent agent;

    public Vector2[] checkpoints;
    int current;
    Vector3 checkpoint;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        checkpoint = new Vector3(checkpoints[current].x, 0, checkpoints[current].y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(checkpoint, transform.position) <= agent.stoppingDistance)
            NextCheckpoint();
    }

    void NextCheckpoint()
    {
        current++;
        if (current == checkpoints.Length)
            current = 0;

        checkpoint = new Vector3(checkpoints[current].x, 0, checkpoints[current].y);
        agent.destination = checkpoint;
    }
}
