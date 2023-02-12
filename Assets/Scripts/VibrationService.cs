using Player;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class VibrationService : MonoBehaviour
{
    public bool IsVibrationOn = true;

    [SerializeField] private PlayerAction playerAction;

    private const string Vibrate = "Vibrate";
    public void ToggleVibration(bool enable)
    {
        IsVibrationOn = enable;
        PlayerPrefs.SetInt(Vibrate, enable ? 1 : 0);
    }
    private void Start()
    {
        playerAction.SubscribeDie(TriggerVibrate);
        if (PlayerPrefs.HasKey(Vibrate))
        {
            if(PlayerPrefs.GetInt(Vibrate) != 0)
            {
                IsVibrationOn = true;
            }
        }
    }
    public void TriggerVibrate()
    {
        if (!IsVibrationOn)
            return;
        Handheld.Vibrate();
    }
}
