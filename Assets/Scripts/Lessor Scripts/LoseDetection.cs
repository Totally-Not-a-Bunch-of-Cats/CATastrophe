using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseDetection : MonoBehaviour
{
    //looks for objects with teh item tag and then reports to the match manger the loss of life
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Debug.Log("mep you lost");
        }
    }
}
