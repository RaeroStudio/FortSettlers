using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resourcesText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI settlersCountText;

    private void Start()
    {
        InitializeHUD();
    }

    private void InitializeHUD()
    {
        // TODO: Инициализация данных HUD
        UpdateResourcesText(0, 0, 0);
        UpdateTimeText("00:00");
        UpdateSettlersCount(0);
    }

    public void UpdateResourcesText(int wood, int stone, int food)
    {
        if (resourcesText != null)
        {
            resourcesText.text = $"🌳 Дерево: {wood}  | 🪨 Камень: {stone}  | 🍎 Еда: {food}";
        }
    }

    public void UpdateTimeText(string time)
    {
        if (timeText != null)
        {
            timeText.text = time;
        }
    }

    public void UpdateSettlersCount(int count)
    {
        if (settlersCountText != null)
        {
            settlersCountText.text = $"Поселенцы: {count}";
        }
    }
} 