using UnityEngine;

namespace Player
{
    public class PlayerAction : MonoBehaviour, IInteractable
    {
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private float speed = 5f;
        [SerializeField] private Score score;

        private Vector3 _direction;
        void Start()
        {
            _direction = Vector3.forward;
        }

        void FixedUpdate()
        {
            rigidbody.velocity = _direction * speed;
        }
        public void ScoreAdd(int value = 1)
        {
            score.Add(value);
        }
        public void Die()
        {
            Debug.Log("Die");
        }
    }
}
