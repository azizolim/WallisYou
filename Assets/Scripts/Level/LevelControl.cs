using Input;
using ObstacleLogic;
using UI;
using UnityEngine;

namespace Level
{
    public class LevelControl : MonoBehaviour, IInit<WinDelegate>
    {
        [SerializeField] private LevelLinks[] levels;
        [SerializeField] private InputService inputService;
        private string _currentLevel = "CurrentLevel";
        private LevelLinks _currentLevelInstance;

        private void Awake()
        {
            if (!PlayerPrefs.HasKey(_currentLevel))
            {
                PlayerPrefs.SetInt(_currentLevel, 0);
                Instantiate(PlayerPrefs.GetInt(_currentLevel));
            }
            else
            {
                Instantiate(PlayerPrefs.GetInt(_currentLevel));
            }
        }

    
        private void Instantiate(int level)
        {
            if (level > levels.Length-1)
            {
                level = 0;
                PlayerPrefs.SetInt(_currentLevel, level);
            }
            _currentLevelInstance= Instantiate(levels[level]);
            _currentLevelInstance.TryGetComponent(out ObstacleService service);
            service.SetInputService(inputService);
        }

        public void Initialize(WinDelegate @delegate)
        {
            _currentLevelInstance.TriggerFinish.SubscribeWin(@delegate);
        }
    }
}
