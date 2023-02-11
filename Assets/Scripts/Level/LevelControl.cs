using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    [SerializeField] private LevelLinks[] levels;
    [SerializeField] private InputService inputService;
    private string _currentLevel = "CurrentLevel";
    public LevelLinks CurrentLevel { get; private set; }

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
       CurrentLevel= Instantiate(levels[level]);
       CurrentLevel.TryGetComponent(out ObstacleService service);
       service.SetInputService(inputService);
    }
}
