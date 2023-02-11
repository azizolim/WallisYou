using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Control : MonoBehaviour
    {
        [SerializeField] private Joystick fixedJoystick;
        [SerializeField] private RotateWithTheArrows leftRotation;
        [SerializeField] private RotateWithTheArrows rightRotation;
        public Joystick FixedJoystick => fixedJoystick;
        public RotateWithTheArrows LeftRotation => leftRotation;
        public RotateWithTheArrows RightRotation => rightRotation;
    }
}