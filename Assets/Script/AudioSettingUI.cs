using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsUI : MonoBehaviour
{
    [Header("UI Elements")]
    public Slider musicSlider;
    public Slider sfxSlider;

    [Header("References")]
    private AuthManager authManager;

    public void SettingUp()
    {
        authManager = GetComponent<AuthManager>();

        // Check if the authManager and currentUser are available
        if (authManager == null || authManager.currentUser == null)
        {
            Debug.LogError("AuthManager or currentUser not found!");
            return;
        }

        // Set sliders to current user values
        float musicVol = authManager.currentUser.Music;
        float sfxVol = authManager.currentUser.SFX;

        musicSlider.value = musicVol;
        sfxSlider.value = sfxVol;

        // Listen for changes
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        // Apply to audio manager
        SetMusicVolume(musicVol);
        SetSFXVolume(sfxVol);
    }

    public void SetMusicVolume(float volume)
    {
        AudioManager.Instance.SetMusicVolume(volume);
        if (authManager.currentUser != null)
            authManager.currentUser.Music = volume;
    }

    public void SetSFXVolume(float volume)
    {
        AudioManager.Instance.SetSFXVolume(volume);
        if (authManager.currentUser != null)
            authManager.currentUser.SFX = volume;
    }
}
