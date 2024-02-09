using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class PatrollingScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] points;

    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private GameObject player;

    private int currPoint;
    

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        currPoint = 0;
        agent.destination = points[currPoint].transform.position;
        Vector3 vel = agent.velocity;
        
    }

    private void Update()
    {

        if (Vector3.Distance(this.transform.position, points[currPoint].transform.position) <= 2f)
        {
            Iterate();
        }
        if (agent.velocity.magnitude < 0.15f)
        {
            agent.destination = points[currPoint].transform.position;
        }


    }
    public void Iterate()
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

    public void SeePlayer()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) <= 10f)
        {
            agent.destination = player.transform.position;
            
        }
    }
    

}
