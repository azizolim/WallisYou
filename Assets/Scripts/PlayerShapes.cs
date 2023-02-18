using Player;
using System;
using System.Collections;
using UnityEngine;

public class PlayerShapes : MonoBehaviour
{
    [SerializeField] private float delayToSwapShape;
    [SerializeField] private PlayerAction[] shapes;
    [SerializeField] private PlayerAction curentShape;
    [SerializeField] private Vibration vibration;
    public void SwitchShape(int shapeType)
    {
        StartCoroutine(Switch(shapeType));
    }
    IEnumerator Switch(int shapeType)
    {
        PlayerAction shape = shapes[shapeType];
        yield return new WaitForSeconds(delayToSwapShape);
        if (curentShape == shape)
        {
            yield break;
        }
        vibration.TriggerVibrate();
        Destroy(curentShape);
        curentShape = shape;
        Instantiate(curentShape);
    }
}
