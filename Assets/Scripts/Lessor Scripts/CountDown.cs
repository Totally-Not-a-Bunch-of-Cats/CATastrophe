using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    [SerializeField] TMP_Text Text;
    [SerializeField] List<string> ListString;
    [SerializeField] int ListNum;

    private void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(CountDowns());
    }
    public IEnumerator CountDowns()
    {
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
            GameManager.Instance._MatchManager.StartMatch();
        }
    }
}
