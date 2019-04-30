using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    RaycastHit hitInfo;
    Ray raycast;
    public GameObject reticle;
    private bool materialChange;

    void Update()
    {
            PerformRaycast();      
    }

    private void PerformRaycast()
    {
        
        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hitInfo,100f))
        {
            reticle.GetComponent<SpriteRenderer>().color = Color.green;

            if (Input.GetButtonDown("Fire1"))
            {
                materialChange = !materialChange;
                if(materialChange)
                    hitInfo.transform.GetComponent<Renderer>().material.color = Color.black;
                else
                    hitInfo.transform.GetComponent<Renderer>().material.color = Color.yellow;
            }

        }
        else
        {

            reticle.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
