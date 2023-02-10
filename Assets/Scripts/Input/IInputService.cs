using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputService
{
    public Vector3 RotateDirection { get; set; }
    public Vector3 MoveDirection { get; set; }

}
