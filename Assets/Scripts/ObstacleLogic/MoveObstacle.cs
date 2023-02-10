using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    private IInputService _inputService;

    void Start()
    {
        //����� �� ������� �������� _inputService
    }

    void Update()
    {
        if (_inputService.MoveDirection != Vector3.zero)
        {
            transform.Translate(_inputService.MoveDirection * moveSpeed * Time.deltaTime, Space.World);
        }
        if (_inputService.RotateDirection != Vector3.zero)
        {
            transform.Rotate(_inputService.RotateDirection * rotateSpeed);
        }
    }
}
