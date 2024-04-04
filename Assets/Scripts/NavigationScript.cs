using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{
    public Transform player;
    public Transform[] patrolPoints;
    private NavMeshAgent agent;
    private int destPoint = 0;
    public float updateInterval = 0.1f;
    public float idleTime = 3f; // Idle time before moving to the next point

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(UpdateDestination());
    }

    // Update is called once per frame
    IEnumerator UpdateDestination()
    {
        while (true)
        {
            yield return new WaitForSeconds(updateInterval);

            // If player is within a certain distance, set player position as destination
            if (Vector3.Distance(transform.position, player.position) < 10f)
            {
                agent.destination = player.position;
            }
            else // Otherwise, continue patrol
            {
                // Check if the agent has reached the destination patrol point
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                {
                    yield return new WaitForSeconds(idleTime); // Idle before moving to the next point
                    GotoNextPoint();
                }
            }
        }
    }

    void GotoNextPoint()
    {
        // If no patrol points are set up, return
        if (patrolPoints.Length == 0)
            return;

        // Set the agent's destination to the current patrol point
        agent.destination = patrolPoints[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % patrolPoints.Length;
    }
}