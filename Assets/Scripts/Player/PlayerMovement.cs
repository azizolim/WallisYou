using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour, IInteractable
    {
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private float speed = 5f;

        private Vector3 _direction;
        void Start()
        {
            _direction = Vector3.forward;
        }

        void FixedUpdate()
        {
            rigidbody.AddForce(_direction * speed);
        }

        public void Die()
        {
            Debug.Log("Die");
        }
    }
}
