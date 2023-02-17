
namespace Player
{
    public interface IInteractable
    {
        public void Die();
        public void AddScore(int score);
        public void SetPosition(int key);
    }
}