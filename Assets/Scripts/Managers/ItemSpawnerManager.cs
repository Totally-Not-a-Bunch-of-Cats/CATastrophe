using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerManager : MonoBehaviour
{
    public List<GameObject> ItemSpawerList;
    public List<GameObject> Item;
    [SerializeField] int SpawnCount;
    [SerializeField] float WaveOffset = 2f;


    public void WaveDelay()
    {
        for(int i = 0; i < ItemSpawerList.Count; i++)
        {
            StartCoroutine(Spawn(i));
        }
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        yield return new WaitUntil(() => SpawnCount >= ItemSpawerList.Count);
        print("wave delayed");
        yield return new WaitForSeconds(WaveOffset);
        SpawnCount = 0;
        if (!GameManager.Instance._LifeManager.GameOver)
        {
            WaveDelay();
        }
    }
    
    /// <summary>
    /// has a random delay between .5 to 4 the instantiates a random item.
    /// </summary>
    /// <param name="SpawnerNum"></param>
    /// <returns></returns>
    IEnumerator Spawn(int SpawnerNum)
    {
        float RandomDelay = Random.Range(1.5f, 5f);
        yield return new WaitForSeconds(RandomDelay);
        int temp = Random.Range(0, Item.Count);
        Instantiate(Item[temp], ItemSpawerList[SpawnerNum].transform);
        SpawnCount += 1;
    }
}
