using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


        if (!PlayerPrefs.HasKey("Level"))
            PlayerPrefs.SetInt("Level", 1);

    }

    private void OnEnable()
    {
        EventManager.OnLevelCompleted += LevelCompleted;
    }
    private void OnDisable()
    {
        EventManager.OnLevelCompleted -= LevelCompleted;
    }


    public void LevelCompleted() 
    {
        PlayerPrefs.SetInt("Level", GetLevel() + 1);
    }

    
    public int GetLevel() { return PlayerPrefs.GetInt("Level"); }
}
