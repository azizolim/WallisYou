using UnityEngine;

namespace Level
{
    public class LevelLinks : MonoBehaviour
    {
        [SerializeField] private TriggerFinish finish;

        public TriggerFinish TriggerFinish => finish;
    }
}
