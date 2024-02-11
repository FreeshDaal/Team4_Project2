using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;
    public GameObject Fog;


    void OnTriggerEnter(Collider other) //just enables the bool of having a key and turns of gameobject
    {
        if (other.transform == player)
        {
            gameEnding.isHoldingKey = true;
            this.gameObject.SetActive(false);
            Fog.SetActive(true);
        }
    }
    void Start()
    {
        this.gameObject.SetActive(true);
    }

}    
