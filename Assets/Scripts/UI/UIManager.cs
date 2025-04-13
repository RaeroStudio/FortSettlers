using UnityEngine;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private Canvas mainCanvas;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject hudPanel;

    private Dictionary<string, GameObject> activePanels = new Dictionary<string, GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitializeUI();
    }

    private void InitializeUI()
    {
        // Инициализация базовых панелей
        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(true);
            activePanels["MainMenu"] = mainMenuPanel;
        }

        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
            activePanels["Settings"] = settingsPanel;
        }

        if (hudPanel != null)
        {
            hudPanel.SetActive(false);
            activePanels["HUD"] = hudPanel;
        }
    }

    public void ShowPanel(string panelName)
    {
        if (activePanels.ContainsKey(panelName))
        {
            activePanels[panelName].SetActive(true);
        }
    }

    public void HidePanel(string panelName)
    {
        if (activePanels.ContainsKey(panelName))
        {
            activePanels[panelName].SetActive(false);
        }
    }

    public void TogglePanel(string panelName)
    {
        if (activePanels.ContainsKey(panelName))
        {
            activePanels[panelName].SetActive(!activePanels[panelName].activeSelf);
        }
    }
} 