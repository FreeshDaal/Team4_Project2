using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogCloud : MonoBehaviour
{

    public GameObject Fog;
    public GameObject Ground;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Fog.transform.position = Vector3.MoveTowards(Fog.transform.position, Ground.transform.position, speed); //Moves fog cloud to ground on spawn
    }

}
