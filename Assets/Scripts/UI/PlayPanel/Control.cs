using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Control : MonoBehaviour
    {
        [SerializeField] private Joystick fixedJoystick;
        [SerializeField] private Button leftRotation;
        [SerializeField] private Button rightRotation;

        public Joystick FixedJoystick => fixedJoystick;
        public Button LeftRotation => leftRotation;
        public Button RightRotation => rightRotation;
    }
}