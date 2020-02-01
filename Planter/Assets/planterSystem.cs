using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class planterSystem : MonoBehaviour
{
  //  public Vector3 spawnHere;
    
    public GameObject seed;
    public GameObject plantLocation;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name=="plantLocation")
        {
         
            Instantiate(seed,plantLocation.transform.position,Quaternion.identity);
        }
    }

    
}

