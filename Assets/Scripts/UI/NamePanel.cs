using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class NamePanel : MonoBehaviour
{
    [SerializeField] private Button saveButton;
    [SerializeField] private TMP_InputField playerID;
    [SerializeField] private LeaderboardController leaderboardController;

    private UnityAction _action;
    private UnityAction _action1;
    public void SubscribeAction(UnityAction action, UnityAction action1)
    {
        _action = action;
        _action1 = action1;
    }

    private void Start()
    {
        saveButton.onClick.AddListener(SetID);
    }

    private void SetID()
    {
        PlayerPrefs.SetString("PlayerID", playerID.text);
        leaderboardController.SetPlayerName();
        _action?.Invoke();
        _action1?.Invoke();
        
    }
}
