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
    }
}
