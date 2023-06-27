using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracking : MonoBehaviour
{
    public GameObject track;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")){
            track = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //track = null;
    }

}
