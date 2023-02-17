using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class TriggerMesh : MonoBehaviour
{
    [SerializeField] private Mesh mesh;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            interactable.SetMesh(mesh);
        }
    }
}
