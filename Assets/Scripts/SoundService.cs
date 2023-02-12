using UnityEngine;
using UnityEngine.Audio;

public class SoundService : MonoBehaviour
{
    private const string Music = "Music";
    private const string Effects = "Effects";
    [SerializeField] private AudioMixerGroup audioMixerGroup;
    private void Start()
    {
        if (PlayerPrefs.HasKey(Music))
            audioMixerGroup.audioMixer.SetFloat(Music, PlayerPrefs.GetInt(Music));
        if (PlayerPrefs.HasKey(Effects))
            audioMixerGroup.audioMixer.SetFloat(Effects, PlayerPrefs.GetInt(Effects));
    }
    public void ToggleMusic(bool enable)
    {
        if (enable)
        {
            audioMixerGroup.audioMixer.SetFloat(Music, 0);
            PlayerPrefs.SetInt(Music, 0);
        }
        else
        {
            audioMixerGroup.audioMixer.SetFloat(Music, -80);
            PlayerPrefs.SetInt(Music, -80);
        }
    }
    public void ToggleEffects(bool enable)
    {
        if (enable)
        {
            audioMixerGroup.audioMixer.SetFloat(Effects, 0);
            PlayerPrefs.SetInt(Effects, 0);
        }
        else
        {
            audioMixerGroup.audioMixer.SetFloat(Effects, -80);
            PlayerPrefs.SetInt(Effects, -80);

        }
    }
}
