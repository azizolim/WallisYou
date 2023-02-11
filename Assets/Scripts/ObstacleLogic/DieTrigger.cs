using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTrigger : Obstacle
{
    
    public override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerAction>(out PlayerAction playerAction))
        {
            playerAction.Die();
        }
    }

}
