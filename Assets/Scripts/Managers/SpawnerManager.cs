using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public List<GameObject> SpawnArea;
    public List<GameObject> Item;
    [SerializeField] int SpawnNum = 2;
    [SerializeField] int Spawned = 0;
    public float WaveOffset = 2f;
    public int SpawnRangeLow = 2;
    public int SpawnRangeHigh = 5;
    public float RandomDelayLow = 1;
    public float RandomDelayHigh = 5;
    public bool FirstWave = true;


    public void SpawnBuffer()
    {
        SpawnNum = Random.Range(SpawnRangeLow, SpawnRangeHigh);
        print(SpawnNum);
        for (int i = 0; i < SpawnNum; i++)
        {
            StartCoroutine(Spawn());
        }
        StartCoroutine(Delay());
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator Delay()
    {
        yield return new WaitUntil(() => SpawnNum <= Spawned);
        print("wave delayed Starting");
        Spawned = 0;
        yield return new WaitForSeconds(WaveOffset);
        print("wave delayed finished");
        if (!GameManager.Instance._LifeManager.GameOver)
        {
            SpawnBuffer();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="SpawnerNum"></param>
    /// <returns></returns>
    IEnumerator Spawn()
    {
        float RandomDelay = 0;
        if (FirstWave)
        {
            RandomDelay = 0;
            FirstWave = false;
        }
        else
        {
            RandomDelay = Random.Range(RandomDelayLow, RandomDelayHigh);
        }
        yield return new WaitForSeconds(RandomDelay);
        Spawned += 1;
        int tempInt = Random.Range(0, Item.Count); //random item
        Vector3 tempV3 = new Vector3(Random.Range(SpawnArea[0].transform.position.x, SpawnArea[1].transform.position.x), 0, Random.Range(SpawnArea[0].transform.position.z, SpawnArea[2].transform.position.z));
        Instantiate(Item[tempInt], tempV3, Quaternion.identity);
    }
}
