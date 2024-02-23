using System.Collections;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private int CurrentPoints = 0;
    [SerializeField] private int TimeBonus = 1;
    [SerializeField] private GameObject PointsObj;
    //called by game or match manger need to decided or reword to work off of update

    private void OnEnable()
    {
        StartCoroutine(PointIncrement());
    }
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

    IEnumerator PointIncrement()
    {
        yield return new WaitForSeconds(.25f);
        AddTimePoints();
    }

    IEnumerator UpgradeTimeBonus()
    {
        yield return new WaitForSeconds(20);
        TimeBonus += 1;
    }
}
