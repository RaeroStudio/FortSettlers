using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private Vector2 cameraBounds = new Vector2(100f, 100f);
    [SerializeField] private float minHeight = 5f;
    [SerializeField] private float maxHeight = 50f;

    private Vector3 lastMousePosition;
    private bool isRotating = false;
    private float currentHeight;

    private void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        currentHeight = mainCamera.transform.position.y;
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleZoom();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;

        // Ограничение движения камеры
        newPosition.x = Mathf.Clamp(newPosition.x, -cameraBounds.x, cameraBounds.x);
        newPosition.z = Mathf.Clamp(newPosition.z, -cameraBounds.y, cameraBounds.y);
        newPosition.y = currentHeight;

        transform.position = newPosition;
    }

    private void HandleRotation()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }

        if (isRotating)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            float deltaX = (currentMousePosition.x - lastMousePosition.x) * rotationSpeed * Time.deltaTime;
            
            transform.Rotate(Vector3.up, deltaX);
            lastMousePosition = currentMousePosition;
        }
    }

    private void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            currentHeight -= scroll * zoomSpeed;
            currentHeight = Mathf.Clamp(currentHeight, minHeight, maxHeight);
            
            Vector3 newPosition = transform.position;
            newPosition.y = currentHeight;
            transform.position = newPosition;

            // Настройка угла обзора камеры в зависимости от высоты
            float normalizedHeight = (currentHeight - minHeight) / (maxHeight - minHeight);
            mainCamera.fieldOfView = Mathf.Lerp(60f, 30f, normalizedHeight);
        }
    }

    public void SetCameraBounds(Vector2 bounds)
    {
        cameraBounds = bounds;
    }

    public void ResetCamera()
    {
        transform.position = new Vector3(0f, (minHeight + maxHeight) / 2f, 0f);
        transform.rotation = Quaternion.identity;
        currentHeight = (minHeight + maxHeight) / 2f;
        mainCamera.fieldOfView = 45f;
    }
} 