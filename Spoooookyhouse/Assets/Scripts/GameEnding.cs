using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{

    public GameObject player;
    bool isPlayerAtExit;
    public bool isHoldingKey;
    bool isPlayerCaught;

    void OnTriggerEnter(Collider other) //if player is within the exit area this is true
    {
        if (other.gameObject == player)
        {
            isPlayerAtExit = true;
        }
    }
    void OnTriggerExit(Collider other) // if they leave the area it turns off
    {
        if (other.gameObject == player)
        {
            isPlayerAtExit = false;
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
            //add end screen!
        }
        else if (isPlayerCaught)
        {
            Debug.Log("You Died!");
            SceneManager.LoadScene(0);

        }
    }
    private void Start()
    {
        isHoldingKey = false;
    }
}
