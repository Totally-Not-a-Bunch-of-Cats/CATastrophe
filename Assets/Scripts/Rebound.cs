using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebound : MonoBehaviour
{
    [SerializeField] private VisualPoints Points;
    [SerializeField] private float PointsMultiplier = 1;
    public float Force = 2000f;
    public int PointsValue = 200;
    private void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.AddForce(collision.rigidbody.velocity.normalized * Force);
        Points.Pointss = (int)(PointsValue * PointsMultiplier);
        Points.SummonPoints();
        GameManager.Instance._MatchManager.AddPoints(PointsValue);
        PointsMultiplier += .01f;
    }
}