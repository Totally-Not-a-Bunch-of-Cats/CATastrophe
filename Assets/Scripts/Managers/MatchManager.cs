using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    //lives till loss
    [SerializeField] private int Lives = 3;
    //tracks current points
    [SerializeField] private int CurrentPoints = 0;
    //time bonus for points
    [SerializeField] private int TimeBonus = 1;
    //the points counter
    [SerializeField] private GameObject PointsObj;

    private void OnEnable()
    {
        StartCoroutine(PointIncrement());
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

    /// <summary>
    /// called when you watch an ad to reset 
    /// </summary>
    /// <param name="life"> amount of life to be gained</param>
    public void LifeGain(int life)
    {
        Lives = life;
        if(Lives < 3)
        {
            Lives = 3;
        }
    }
    /// <summary>
    /// is called when an item is let through to decrement a life.
    /// </summary>
    public void LifeLoss()
    {
        Lives += 1;
        if(Lives <= 0)
        {
            GameOver();
        }
    }
    /// <summary>
    /// gets called when lives reaches zero
    /// </summary>
    void GameOver()
    {

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
        yield return new WaitForSeconds(.25f);
        AddTimePoints();
    }
}
