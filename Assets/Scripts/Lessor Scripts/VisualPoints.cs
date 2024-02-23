using TMPro;
using UnityEngine;

public class VisualPoints : MonoBehaviour
{
    [SerializeField] GameObject PointsPrefab;
    /// <summary>
    /// This script is attached to the items and will summon a decaying floating number of the points earned
    /// </summary>
    public void SummonPoints()
    {
        //update this to work
        Instantiate(PointsPrefab, transform.position, Quaternion.identity, transform);
    }
}