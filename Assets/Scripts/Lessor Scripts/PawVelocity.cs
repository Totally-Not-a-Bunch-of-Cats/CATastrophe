using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawVelocity : MonoBehaviour
{
    public Vector3 Velocity;
    [SerializeField] Vector3 CurrentPos;

    void FixedUpdate()
    {
        if(CurrentPos == null)
        {
            CurrentPos = transform.position; //maybe localposition 
        }
        else
        {
            Vector3 NewPos = transform.position;
            Velocity = (CurrentPos - NewPos) /Time.deltaTime;
            CurrentPos = NewPos;
        }
    }
}
