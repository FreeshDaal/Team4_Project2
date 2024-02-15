using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogStarter : MonoBehaviour
{
    public GameObject Fog;
    public Transform player;
    public GameObject GhostTopFloor;
    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {

            Fog.SetActive(true);
            GhostTopFloor.SetActive(true);
        }
    }
}
