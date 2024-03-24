using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    //lives till loss
    [SerializeField] private int Lives = 3;
    public List<GameObject> Life;
    [SerializeField] int Pos = 0;

    public void LoseLife()
    {
        Life[Pos].GetComponent<Image>().color = Color.black;
        Pos++;
        Lives--;
        if (Lives <= 0)
        {
            //GameOver();
        }
    }

    /// <summary>
    /// called when you watch an ad to reset 
    /// </summary>
    /// <param name="life"> amount of life to be gained</param>
    public void LifeGain(int life)
    {
        Lives = life;
        if (Lives < 3)
        {
            Lives = 3;
        }
    }
}
