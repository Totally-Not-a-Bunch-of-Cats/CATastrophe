/** @Author Aaron */
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //other Managers
    public MatchManager _MatchManager;
    public LifeManager _LifeManager;
    public SpawnerManager _SpawnerManager;
    public DifficultlyManager _DifficultlyManager;


    // Singleton Varables
    //Check to see if we're about to be destroyed.
    private static bool m_ShuttingDown = false;
    private static object m_Lock = new object();
    private static GameManager m_Instance;
    public static GameManager Instance
    {
        get
        {
            if (m_ShuttingDown)
            {
                Debug.LogWarning("[Singleton] Instance '" + typeof(GameManager) +
                    "' already destroyed. Returning null.");
                return null;
            }
            lock (m_Lock)
            {
                if (m_Instance == null)
                {
                    // Search for existing instance.
                    m_Instance = (GameManager)FindObjectOfType(typeof(GameManager));
                    // Create new instance if one doesn't already exist.
                    if (m_Instance == null)
                    {
                        // Need to create a new GameObject to attach the singleton to.
                        var singletonObject = new GameObject();
                        m_Instance = singletonObject.AddComponent<GameManager>();
                        singletonObject.name = typeof(GameManager).ToString() + " (Singleton)";
                        // Make instance persistent.
                        DontDestroyOnLoad(singletonObject);
                    }
                }
                return m_Instance;
            }
        }
    }
    private void Start()
    {
        //_MatchManager.StartCountdown();
    }

    public void Restart()
    {
        StartCoroutine(StartMatch());
    }

    public IEnumerator StartMatch()
    {
        yield return new WaitForEndOfFrame();
        SceneManager.LoadScene("Round");
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
    }
}
