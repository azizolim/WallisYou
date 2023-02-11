using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteTrigger : Obstacle
{
    public delegate void CompleteHandler();
    event CompleteHandler _complete;
    public override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerAction>(out PlayerAction playerAction))
        {
            playerAction.ScoreAdd();
            _complete?.Invoke();
        }
    }
    public void SubscribeToComplete(CompleteHandler subscriber)
    {
        _complete += subscriber;
    }
    public void UnsubscribeFromComplete(CompleteHandler subscriber)
    {
        _complete -= subscriber;
    }
}
