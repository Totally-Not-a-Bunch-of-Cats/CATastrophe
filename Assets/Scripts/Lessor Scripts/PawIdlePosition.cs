using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawIdlePosition : MonoBehaviour
{
    public Vector3 IdlePos;
    // Update is called once per frame
    void Update()
    {
        if(false)
        {
            transform.position = IdlePos;
        }
    }
}
