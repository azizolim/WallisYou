using Bank;
using DG.Tweening;
using OnlineLeaderboards;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerAction : MonoBehaviour, IInteractable, IInit<Die>
    {
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private float speed = 5f;
        [SerializeField] private Score score;
        [SerializeField] private LeaderboardController leaderboard;
        private bool _isPaused;
        private bool _isDead;
        private event Die _die;
        private Reborn _reborn;

        private PauseDelegate _pauseDelegate;
        private Vector3 _direction;

        public Reborn RebornDelegate => _reborn;
        public PauseDelegate PauseDelegate => _pauseDelegate;
        public Score Score => score;

        void Awake()
        {
            _direction = Vector3.forward;
            _pauseDelegate = Pause;
            _reborn = Reborn;
        }

        void FixedUpdate()
        {
            if (_isDead || _isPaused) return;
            rigidbody.velocity = _direction * speed;
        }

        public void AddScore(int value = 1)
        {
            score.Add(value);
        }

        public void Die()
        {
            _isDead = true;
            Debug.Log("Die");
            _die?.Invoke();
        }

        private void Pause()
        {
            _isPaused = !_isPaused;
        }

        private void Reborn()
        {
            _isDead = false;
            transform.DOMoveZ(transform.position.z - 15, 0.5f);
        }

        public void Initialize(Die @delegate)
        {
            _die += @delegate;
        }
    }

    public delegate void Reborn();

    public delegate void Die();
}