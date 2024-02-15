using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;
    bool isPlayerInRange;

    void OnTriggerEnter(Collider other) //Checks if player is within collider
    {
        if (other.transform == player)
        {
            isPlayerInRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            isPlayerInRange = false;
        }
    }
    void Update()
    {
        if (isPlayerInRange) 
        {
            gameEnding.CaughtPlayer();
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
