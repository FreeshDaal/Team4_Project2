using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;


    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            gameEnding.isHoldingKey = true;
            this.gameObject.SetActive(false);
        }
    }
    void Start()
    {
        this.gameObject.SetActive(true);
    }

}    
