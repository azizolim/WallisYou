using System.Collections.Generic;
using Input;
using UnityEngine;

namespace ObstacleLogic
{
    public class ObstacleService : MonoBehaviour
    {
        [SerializeField] private List<MoveObstacle> obstacles;
        [SerializeField] private List<CompleteTrigger> completeTriggers;
        [SerializeField] private MoveObstacle[] curentObstacles;
        private InputService _inputService;

        public void SetInputService(InputService inputService)
        {
            _inputService = inputService;
        }
    
        private void Start()
        {
            foreach (CompleteTrigger item in completeTriggers)
            {
                item.SubscribeToComplete(OnObstacleComplete);
            }
            foreach (MoveObstacle item in curentObstacles)
            {
                _inputService.SubscribeToArrows(item.OnRotate);
                _inputService.SubscribeToJoystick(item.OnMove);
            }
        }

        private void OnObstacleComplete()
        {
            foreach (var item in curentObstacles)
            {
                _inputService.UnsubscribeFromArrows(item.OnRotate);
                _inputService.UnsubscribeFromJoystick(item.OnMove);
                Destroy(item.gameObject);
            }
            MoveObstacle[] newCurrentObstacles = new MoveObstacle[obstacles[0].ObstacleQuantity];
            for (int i = 0; i < newCurrentObstacles.Length; i++)
            {
                newCurrentObstacles[i] = obstacles[0];
                _inputService.SubscribeToArrows(newCurrentObstacles[i].OnRotate);
                _inputService.SubscribeToJoystick(newCurrentObstacles[i].OnMove);
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
}
