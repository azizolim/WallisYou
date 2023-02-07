using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;
    private string _currentLevel = "CurrentLevel";

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(_currentLevel))
        {
            PlayerPrefs.SetInt(_currentLevel, 0);
            Instantiate(PlayerPrefs.GetInt(_currentLevel));
        }
        else
        {
            Instantiate(PlayerPrefs.GetInt(_currentLevel));
        }
    }

    
    private void Instantiate(int level)
    {
        if (level > levels.Length-1)
        {
            level = 0;
            PlayerPrefs.SetInt(_currentLevel, level);
        }
        Instantiate(levels[level]);
    }
}
