using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultlyManager : MonoBehaviour
{
    float ReduceWaveDelayWaitTime = 30f;
    float IncreaseSpawnNumHigh_lowWaitTime = 30f;
    float IncreaseRandomDelayHigh_lowWaitTime = 30f;
    float IncreaseBeltSpeedTime = 30f;
    GameObject Belt;
    public IEnumerator IncreaseDifficulty()
    {
        IncreaseBeltSpeed();
        yield return new WaitForSeconds(10f);
        ReduceWaveDelay();
        yield return new WaitForSeconds(10f);
        IncreaseSpawnNumHigh();
        yield return new WaitForSeconds(10f);
        ReduceRandomDelayHigh();
        yield return new WaitForSeconds(10f);
    }


    void IncreaseBeltSpeed()
    {
        if(!Belt)
        {
            Belt = GameObject.FindGameObjectWithTag("Belt");
        }
        print("beltSpeed");
        if(Belt.GetComponent<ConveyorBelt>().velocity <= 60)
        {
            Belt.GetComponent<ConveyorBelt>().velocity += 2;
            StartCoroutine(WaitIncreaseBeltSpeed(IncreaseBeltSpeedTime));
        }
    }
    IEnumerator WaitIncreaseBeltSpeed(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        IncreaseBeltSpeed();
    }

    /// <summary>
    /// reduces the time between waves by reducing the delay
    /// </summary>
    void ReduceWaveDelay()
    {
        //goes down at a consistant rate
        if(GameManager.Instance._SpawnerManager.WaveOffset >= 1)
        {
            print("wave delay");
            GameManager.Instance._SpawnerManager.WaveOffset -= .05f;
            StartCoroutine(WaitReduceWaveDelay(ReduceWaveDelayWaitTime));
        }
    }
    //wait time in between reductions
    IEnumerator WaitReduceWaveDelay(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        ReduceWaveDelay();
    }

    /// <summary>
    /// Increases the max spawn amount
    /// </summary>
    void IncreaseSpawnNumHigh()
    {
        //alternates between hight and low 
        if (GameManager.Instance._SpawnerManager.SpawnRangeHigh <= 10)
        {
            print("spawn num up");
            GameManager.Instance._SpawnerManager.SpawnRangeHigh += 1;
            StartCoroutine(WaitIncreaseSpawnNumHigh(IncreaseSpawnNumHigh_lowWaitTime));
        }
    }
    //wait time between reduction
    IEnumerator WaitIncreaseSpawnNumHigh(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        IncreaseSpawnNumLow();
    }
    /// <summary>
    /// Increase the min spawn amount
    /// </summary>
    void IncreaseSpawnNumLow()
    {
        //alternates between hight and low 
        if (GameManager.Instance._SpawnerManager.SpawnRangeHigh >= GameManager.Instance._SpawnerManager.SpawnRangeLow)
        {
            print("spawn num down");
            GameManager.Instance._SpawnerManager.SpawnRangeHigh += 1;
            StartCoroutine(WaitIncreaseSpawnNumLow(IncreaseSpawnNumHigh_lowWaitTime));
        }
    }
    //wait time between reduction
    IEnumerator WaitIncreaseSpawnNumLow(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        IncreaseSpawnNumHigh();
    }


    void ReduceRandomDelayHigh()
    {
        //alternates between high and low
        if (GameManager.Instance._SpawnerManager.RandomDelayHigh <= 2)
        {
            print("delay high");
            GameManager.Instance._SpawnerManager.RandomDelayHigh -= .05f;
            StartCoroutine(WaitReduceRandomDelayHigh(IncreaseRandomDelayHigh_lowWaitTime));
        }
    }
    IEnumerator WaitReduceRandomDelayHigh(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        ReduceRandomDelayLow();
    }
    /// <summary>
    /// Reduces the random low bound delay between the wave delay and the spawn
    /// </summary>
    public void ReduceRandomDelayLow()
    {
        //alternates between hight and low
        if (GameManager.Instance._SpawnerManager.RandomDelayLow >= 0)
        {
            print("delay low");
            GameManager.Instance._SpawnerManager.RandomDelayLow -= .01f;
            StartCoroutine(WaitReduceRandomDelayLow(IncreaseRandomDelayHigh_lowWaitTime));
        }
    }
    IEnumerator WaitReduceRandomDelayLow(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        ReduceRandomDelayHigh();
    }



    /// <summary>
    /// Reuses the mechanic to get the wave to spawn instantly
    /// </summary>
    public void SpawnExtraWave()
    {
        GameManager.Instance._SpawnerManager.FirstWave = true;
    }
    public void SpawnEvent()
    {

    }
}
