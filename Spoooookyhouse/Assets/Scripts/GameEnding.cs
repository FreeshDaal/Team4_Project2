using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{

    public GameObject player;
    bool isPlayerAtExit;
    public bool isHoldingKey;
    bool isPlayerCaught;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerAtExit = true;
        }
    }
    public void CaughtPlayer()
    {
        isPlayerCaught = true;
    }

    
    void Update()
    {
        if (isPlayerAtExit && isHoldingKey)
        {
            Debug.Log("You escaped!");
        }
        else if (isPlayerCaught)
        {
            Debug.Log("You Died!");
        }
    }
    private void Start()
    {
        isHoldingKey = false;
    }
}
