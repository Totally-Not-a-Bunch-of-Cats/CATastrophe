using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerManager : MonoBehaviour
{
    public List<GameObject> ItemSpawerList;
    public List<GameObject> Item;


    //spawner script rolls an item then choses a spawner to spawn the armor
    public void Spawner()
    {
        for (int i = 0; i < ItemSpawerList.Count; i++)
        {
            int temp = Random.Range(0, Item.Count + 1);
            Instantiate(Item[temp], ItemSpawerList[i].transform);
            print("mep");
        }
    }
}
