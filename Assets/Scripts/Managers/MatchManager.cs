using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public GameObject Paw;
    //tracks current points
    [SerializeField] private int CurrentPoints = 0;
    //time bonus for points
    [SerializeField] private int TimeBonus = 1;
    //the points counter
    [SerializeField] private GameObject PointsObj;

    [SerializeField] private float PointsDelay = .25f;

    private void OnEnable()
    {
        StartCoroutine(PointIncrement());
    }

    private void Update()
    {
        Vector3 temp = Input.mousePosition;
        temp.z = 130;
        Paw.transform.position = temp;
    }

    /// <summary>
    /// infinite loop for points incriment
    /// </summary>
    private void AddTimePoints()
    {
        CurrentPoints += 1 * TimeBonus;
        UpdateVisual();
        StartCoroutine(PointIncrement());
    }
    /// <summary>
    /// triggers when the player sucesfully gets an item 
    /// </summary>
    /// <param name="points"></param>
    public void AddPoints(int points)
    {
        CurrentPoints += points * TimeBonus;
    }
    /// <summary>
    /// updates the visual of the points
    /// </summary>
    void UpdateVisual()
    {
        PointsObj.GetComponent<TMP_Text>().text = CurrentPoints.ToString();
    }

    IEnumerator UpgradeTimeBonus()
    {
        yield return new WaitForSeconds(20);
        TimeBonus += 1;
    }
    /// <summary>
    /// in infinite loop that ads points
    /// </summary>
    /// <returns></returns>
    IEnumerator PointIncrement()
    {
        yield return new WaitForSeconds(PointsDelay);
        AddTimePoints();
    }
}
