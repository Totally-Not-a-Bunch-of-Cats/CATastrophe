using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    [SerializeField] TMP_Text Text;
    [SerializeField] List<string> ListString;
    [SerializeField] int ListNum;
    bool Started = false;

    private void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(CountDowns());
    }
    public IEnumerator CountDowns()
    {
        if (!Started)
        {
            print("match started");
            Started = true;
            GameManager.Instance._MatchManager.StartMatch();
        }
        Text.text = ListString[ListNum];
        ListNum++;
        yield return new WaitForSeconds(.5f);
        if(!(ListNum == ListString.Count))
        {
            StartCoroutine(CountDowns());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
