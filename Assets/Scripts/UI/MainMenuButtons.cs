using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private AudioClip buttonClickSound;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        if (playButton != null)
        {
            playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        if (settingsButton != null)
        {
            settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        }

        if (exitButton != null)
        {
            exitButton.onClick.AddListener(OnExitButtonClicked);
        }
    }

    private void OnPlayButtonClicked()
    {
        PlayButtonSound();
        UIManager.Instance.ShowPanel("HUD");
        UIManager.Instance.HidePanel("MainMenu");
        Debug.Log("Play button clicked");
    }

    private void OnSettingsButtonClicked()
    {
        PlayButtonSound();
        UIManager.Instance.ShowPanel("Settings");
        UIManager.Instance.HidePanel("MainMenu");
    }

    private void OnExitButtonClicked()
    {
        PlayButtonSound();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    private void PlayButtonSound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }
} 