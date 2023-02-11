using System;
using System.Diagnostics;
using Player;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class CanvasController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup playPanel;
        [SerializeField] private CanvasGroup pausePanel;
        [SerializeField] private CanvasGroup gameOverPanel;
        [SerializeField] private CanvasGroup winPanel;
        [SerializeField] private PlayerAction player;
        [SerializeField] private LevelControl levelControl;
        [SerializeField] private CanvasGroup leaderBoardPanel;
        [SerializeField] private CanvasGroup namePanel;

        private Die _dieDelegate;
        private PauseDelegate _pauseDelegate;
        private WinDelegate _winDelegate;
        private ChangePanel _changePanel;
        
        private event LeaderboardDelegate _leaderboard;
        private event PauseDelegate _pause; 
        

        private void Start()
        {
            _changePanel = new ChangePanel();
            
            InitializeDelegates();
            InitializeSubscribers();
            CheckNewPlayer();
        }

        private void CheckNewPlayer()
        {
            var isNew = PlayerPrefs.HasKey("isNew");
            if (isNew)
            {
                OnPlayPanel();
            }
            else
            {
                PlayerPrefs.SetString("isNew", "");
                _pause?.Invoke();
                _changePanel.SetPanel(namePanel);
            }
        }

        private void InitializeDelegates()
        {
            _dieDelegate = GameOverPanel;
            _pauseDelegate = OnPausePanel;
            _winDelegate = WinPanel;
        }

        private void InitializeSubscribers()
        {
            namePanel.TryGetComponent(out NamePanel name);
            name.SubscribeAction(OnPlayPanel,()=>_pause?.Invoke());
            playPanel.TryGetComponent(out Play play);
            play.PauseSubscribe(player.PauseDelegate);
            play.PauseSubscribe(_pauseDelegate);

            pausePanel.TryGetComponent(out Pause pause);
            pause.SubscribeResume(player.PauseDelegate);
            pause.SubscribeResume(()=>OnPlayPanel());
            _pause += player.PauseDelegate;
            
            gameOverPanel.TryGetComponent(out GameOver gameOver);
            gameOver.SubscribeReborn(player.RebornDelegate);
            gameOver.SubscribeReborn(()=>OnPlayPanel());
            
            leaderBoardPanel.TryGetComponent(out Leaderboard leaderboard);
            _leaderboard += leaderboard.LeaderboardDelegate;
            
            player.SubscribeDie(_dieDelegate);
            
            levelControl.CurrentLevel.TriggerFinish.SubscribeWin(_winDelegate);

        }

        private void OnPlayPanel()
        {
            _changePanel.SetPanel(playPanel);
        }
        private void OnPausePanel()
        {
            _changePanel.SetPanel(pausePanel);
        }
        private void GameOverPanel()
        {
            OnLeaderboard();
            _leaderboard?.Invoke(OnGameOverPanel, player.Score.Value);
            
        }        
        private void OnGameOverPanel()
        {
            _changePanel.SetPanel(gameOverPanel);
        }
        private void WinPanel()
        {
            OnLeaderboard();
            _leaderboard?.Invoke(OnWinPanel, player.Score.Value);
        }
        private void OnWinPanel()
        {
            _changePanel.SetPanel(winPanel);

        }

        private void OnLeaderboard()
        {
            _changePanel.SetPanel(leaderBoardPanel);
        }
    }
    
    public delegate void WinDelegate();

    public delegate void LeaderboardDelegate(UnityAction action, int score);
}

