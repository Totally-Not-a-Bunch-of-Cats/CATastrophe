using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnanItem : MonoBehaviour
{
    public GameObject Item;
    public void SpawnItem()
    {
        Instantiate(Item, transform);
    }
}
