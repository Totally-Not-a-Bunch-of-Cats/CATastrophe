using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public GameObject PawRight;
    public GameObject PawLeft;
    //tracks current points
    [SerializeField] private int CurrentPoints = 0;
    //time bonus for points
    [SerializeField] private int TimeBonus = 1;
    //the points counter
    [SerializeField] private GameObject PointsObj;

    [SerializeField] private float PointsDelay = .25f;

    public void StartCountdown()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("CountDown");
        temp.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void StartMatch()
    {
        StartCoroutine(PointIncrement());
        GameManager.Instance._SpawnerManager.SpawnBuffer();
        StartCoroutine(GameManager.Instance._DifficultlyManager.IncreaseDifficulty());
    }
    /// <summary>
    /// tracks the paw to the mouse in 3D space
    /// </summary>
    private void Update()
    {
        Vector2 mousePos = new Vector2();
        mousePos.x = Input.mousePosition.x;
        mousePos.y = Input.mousePosition.y;
        PawRight.GetComponent<Rigidbody>().position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 100));
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

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void PlayGame()
    {
        Time.timeScale = 1;
    }
}
