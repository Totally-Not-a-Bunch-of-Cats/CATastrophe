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
        GameObject temp = Instantiate(PointsPrefab, transform.position, Quaternion.identity);
        //getting the rotation mostly correct
        Quaternion tempz = Quaternion.identity;
        tempz.x = .53f;
        temp.transform.localRotation = tempz;
    }
}