using UnityEngine;
using System.Collections.Generic;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private LayerMask selectableLayer;
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    private Camera mainCamera;
    private GameObject selectedObject;
    private Material originalMaterial;
    private List<GameObject> selectedObjects = new List<GameObject>();

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        HandleSelection();
    }

    private void HandleSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, selectableLayer))
            {
                GameObject hitObject = hit.collider.gameObject;
                SelectObject(hitObject);
            }
            else
            {
                ClearSelection();
            }
        }
    }

    private void SelectObject(GameObject obj)
    {
        // Очищаем предыдущее выделение
        ClearSelection();

        // Сохраняем оригинальный материал
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            originalMaterial = renderer.material;
            renderer.material = highlightMaterial;
        }

        selectedObject = obj;
        selectedObjects.Add(obj);

        // Вызываем событие выбора объекта
        ISelectable selectable = obj.GetComponent<ISelectable>();
        if (selectable != null)
        {
            selectable.OnSelected();
        }
    }

    private void ClearSelection()
    {
        foreach (GameObject obj in selectedObjects)
        {
            if (obj != null)
            {
                Renderer renderer = obj.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material = defaultMaterial;
                }

                ISelectable selectable = obj.GetComponent<ISelectable>();
                if (selectable != null)
                {
                    selectable.OnDeselected();
                }
            }
        }

        selectedObjects.Clear();
        selectedObject = null;
    }

    public GameObject GetSelectedObject()
    {
        return selectedObject;
    }

    public List<GameObject> GetSelectedObjects()
    {
        return selectedObjects;
    }
}

// Интерфейс для объектов, которые можно выбрать
public interface ISelectable
{
    void OnSelected();
    void OnDeselected();
} 