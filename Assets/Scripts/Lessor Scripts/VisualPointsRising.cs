using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualPointsRising : MonoBehaviour
{
    private void FixedUpdate()
    {
        gameObject.transform.position += new Vector3(0,1,0);
    }
}
