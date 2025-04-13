using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider soundVolumeSlider;
    [SerializeField] private Button backButton;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioSource audioSource;

    private const string MUSIC_VOLUME_KEY = "MusicVolume";
    private const string SOUND_VOLUME_KEY = "SoundVolume";

    private void Start()
    {
        InitializeSettings();
        LoadSettings();
    }

    private void InitializeSettings()
    {
        if (musicVolumeSlider != null)
        {
            musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        }

        if (soundVolumeSlider != null)
        {
            soundVolumeSlider.onValueChanged.AddListener(OnSoundVolumeChanged);
        }

        if (backButton != null)
        {
            backButton.onClick.AddListener(OnBackButtonClicked);
        }
    }

    private void LoadSettings()
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, 0.75f);
        float soundVolume = PlayerPrefs.GetFloat(SOUND_VOLUME_KEY, 0.75f);

        if (musicVolumeSlider != null)
        {
            musicVolumeSlider.value = musicVolume;
        }

        if (soundVolumeSlider != null)
        {
            soundVolumeSlider.value = soundVolume;
        }

        ApplyVolumeSettings(musicVolume, soundVolume);
    }

    private void OnMusicVolumeChanged(float value)
    {
        PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, value);
        ApplyVolumeSettings(value, soundVolumeSlider != null ? soundVolumeSlider.value : 0.75f);
    }

    private void OnSoundVolumeChanged(float value)
    {
        PlayerPrefs.SetFloat(SOUND_VOLUME_KEY, value);
        ApplyVolumeSettings(musicVolumeSlider != null ? musicVolumeSlider.value : 0.75f, value);
    }

    private void ApplyVolumeSettings(float musicVolume, float soundVolume)
    {
        if (audioMixer != null)
        {
            audioMixer.SetFloat("MusicVolume", Mathf.Log10(musicVolume) * 20);
            audioMixer.SetFloat("SoundVolume", Mathf.Log10(soundVolume) * 20);
        }
    }

    private void OnBackButtonClicked()
    {
        UIManager.Instance.ShowPanel("MainMenu");
        UIManager.Instance.HidePanel("Settings");
    }

    private void OnDestroy()
    {
        PlayerPrefs.Save();
    }
} 