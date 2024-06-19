using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VisualPointsRising : MonoBehaviour
{
    [SerializeField] bool Started = false;
    public int Points;
    public TextMeshPro PointsString;
    [SerializeField] float Fade = .01f;
    [SerializeField] float FadeTime = 1;

    private void Start()
    {
        PointsString.text = Points.ToString(); 
    }
    private void FixedUpdate()
    {
        gameObject.transform.position += new Vector3(0,1,0);
        if(!Started)
        {
            Started = true;
            StartCoroutine(ColorFade());
        }
    }

    IEnumerator ColorFade()
    {
        if (gameObject.transform.GetComponent<TextMeshPro>().color.a > .2f)
        {
            Color PointColor = gameObject.transform.GetComponent<TextMeshPro>().color;
            PointColor.a -= Fade;
            gameObject.transform.GetComponent<TextMeshPro>().color = PointColor;
            yield return new WaitForSeconds(FadeTime);
            StartCoroutine(ColorFade());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
