using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    void Start()
    {
        LoadSettings();
    }
    public void BGMSoundsOn()
    {
        PlayerPrefs.SetInt("bgmSounds", 1);
    }
    public void BGMSoundsOff()
    {
        PlayerPrefs.SetInt("bgmSounds", 0);
    }
    public void SFXSoundsOn()
    {
        PlayerPrefs.SetInt("sfxSounds", 1);
    }
    public void SFXSoundsOff()
    {
        PlayerPrefs.SetInt("sfxSounds", 0);
    }
    void LoadSettings()
    {
        if (PlayerPrefs.HasKey("bgmSounds"))
        {
            PlayerPrefs.SetInt("bgmSounds", PlayerPrefs.GetInt("bgmSounds"));
        }
        else
        {
            PlayerPrefs.SetInt("bgmSounds", 1);
        }
        if (PlayerPrefs.HasKey("sfxSounds"))
        {
            PlayerPrefs.SetInt("sfxSounds", PlayerPrefs.GetInt("sfxSounds"));
        }
        else
        {
            PlayerPrefs.SetInt("sfxSounds", 1);
        }
    }
}
