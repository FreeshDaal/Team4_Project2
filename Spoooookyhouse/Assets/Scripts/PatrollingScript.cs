using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class PatrollingScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] points; //these are the waypoints, made into an array so I can make as many as i want

    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private GameObject player;
    public PlayerMovement playerMovement;

    private int currPoint;
    

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        currPoint = 0;
        agent.destination = points[currPoint].transform.position;
        Vector3 vel = agent.velocity;
        
    }

    private void Update() //when this script updates it checks if its near the waypoint if it is it runs the iterate function, it also checks if the navagent as stopped moving if so it goes back to its last waypoint
    {

        if (Vector3.Distance(this.transform.position, points[currPoint].transform.position) <= 2f)
        {
            Iterate();
        }
        if (agent.velocity.magnitude < 0.15f)
        {
            agent.destination = points[currPoint].transform.position;
        }
        if (playerMovement.isSprinting)
        {
            agent.destination = player.transform.position;
        }


    }
    public void Iterate() //this is called when the ghost is near the way point and makes the next waypoint its new destinations
    {
        if (currPoint < points.Length - 1)
        {
            currPoint++;
        }
        else
        {
            currPoint = 0;
        }
        agent.destination = points[currPoint].transform.position;
    }

    public void SeePlayer() //if the ghost is in the FOV of the ghost its changes its way point to the player
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) <= 10f)
        {
            agent.destination = player.transform.position;
            
        }
    }
    

}
