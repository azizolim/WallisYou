using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class ObstacleService : MonoBehaviour
{
    [SerializeField] private List<MoveObstacle> obstacles;
    [SerializeField] private List<CompleteTrigger> completeTriggers;
    [SerializeField] private MoveObstacle[] curentObstacles;
    [SerializeField] private InputService inputService;

    private void Start()
    {
        foreach (CompleteTrigger item in completeTriggers)
        {
            item.SubscribeToComplete(OnObstacleComplete);
        }
        foreach (MoveObstacle item in curentObstacles)
        {
            inputService.SubscribeToArrows(item.OnRotate);
            inputService.SubscribeToJoystick(item.OnMove);
        }
    }

    private void OnObstacleComplete()
    {
        foreach (var item in curentObstacles)
        {
            inputService.UnsubscribeFromArrows(item.OnRotate);
            inputService.UnsubscribeFromJoystick(item.OnMove);
            Destroy(item.gameObject);
        }
        MoveObstacle[] newCurrentObstacles = new MoveObstacle[obstacles[0].ObstacleQuantity];
        for (int i = 0; i < newCurrentObstacles.Length; i++)
        {
            newCurrentObstacles[i] = obstacles[0];
            inputService.SubscribeToArrows(newCurrentObstacles[i].OnRotate);
            inputService.SubscribeToJoystick(newCurrentObstacles[i].OnMove);
            obstacles.RemoveAt(0);
        }
        curentObstacles = newCurrentObstacles;
    }

    private void OnDestroy()
    {

        foreach (CompleteTrigger item in completeTriggers)
        {
            item.UnsubscribeFromComplete(OnObstacleComplete);
        }
    }
}
