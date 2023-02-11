using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Play : MonoBehaviour
    {
        [SerializeField] private Button pauseButton;
        [SerializeField] private Control control;
        public Control Control => control;
        
        private event PauseDelegate _pause;

       
        public void PauseSubscribe(PauseDelegate pauseDelegate)
        {
            _pause += pauseDelegate;
        }

        public void Awake()
        {
            pauseButton.onClick.AddListener(()=> _pause?.Invoke());
        }
    }

    public delegate void PauseDelegate();
   

}
