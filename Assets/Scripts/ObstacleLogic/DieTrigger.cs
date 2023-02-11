using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTrigger : Obstacle
{
    
    public override void OnTriggerEnter(Collider other)
    {
     
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IInteractable playerAction))
        {
            playerAction.Die();
        }
    }
}
