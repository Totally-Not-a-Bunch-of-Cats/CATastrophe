//Author Aaron Tweden
using UnityEngine;

/// <summary>
/// items for the cat to interact with
/// </summary>
[CreateAssetMenu]
public class Item : ScriptableObject
{
    [SerializeField] private GameObject Prefab;
    [SerializeField] private string Name;

    /// <summary>
    /// returns the prefab
    /// </summary>
    public GameObject GetPrefab()
    {
        return Prefab;
    }
}
