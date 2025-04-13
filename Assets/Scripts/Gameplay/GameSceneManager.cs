using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] private Terrain terrain;
    [SerializeField] private Light directionalLight;
    [SerializeField] private Material skyboxMaterial;
    [SerializeField] private float dayNightCycleSpeed = 0.1f;

    private float currentTimeOfDay = 0f;
    private const float DAY_LENGTH = 24f;

    private void Start()
    {
        InitializeScene();
    }

    private void InitializeScene()
    {
        // Настройка ландшафта
        if (terrain != null)
        {
            terrain.terrainData.size = new Vector3(1000f, 100f, 1000f);
            terrain.terrainData.heightmapResolution = 513;
        }

        // Настройка освещения
        if (directionalLight != null)
        {
            directionalLight.transform.rotation = Quaternion.Euler(50f, 30f, 0f);
            directionalLight.intensity = 1f;
        }

        // Настройка неба
        if (skyboxMaterial != null)
        {
            RenderSettings.skybox = skyboxMaterial;
            RenderSettings.ambientIntensity = 1f;
        }
    }

    private void Update()
    {
        UpdateDayNightCycle();
    }

    private void UpdateDayNightCycle()
    {
        if (directionalLight != null)
        {
            currentTimeOfDay += Time.deltaTime * dayNightCycleSpeed;
            currentTimeOfDay %= DAY_LENGTH;

            float sunAngle = (currentTimeOfDay / DAY_LENGTH) * 360f;
            directionalLight.transform.rotation = Quaternion.Euler(sunAngle, 30f, 0f);

            // Настройка интенсивности света в зависимости от времени суток
            float normalizedTime = currentTimeOfDay / DAY_LENGTH;
            if (normalizedTime < 0.25f || normalizedTime > 0.75f)
            {
                directionalLight.intensity = 0.1f;
            }
            else
            {
                directionalLight.intensity = 1f;
            }
        }
    }

    public void LoadGameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
} 