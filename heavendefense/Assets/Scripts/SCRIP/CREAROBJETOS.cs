using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationController : MonoBehaviour
{
    public GameObject[] objectPrefabs;  // Asegúrate de asignar los prefabs en el Inspector

    private int selectedObjectIndex = 0;
    private GameObject selectedObject;

    private bool isCreatingObject = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isCreatingObject)
            {
                CreateObject();
            }
            else
            {
                HandleMouseClick();
            }
        }

        HandleMouseRelease();
    }

    void HandleMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Terrain"))
            {

                StartObjectPlacement(hit.point);
            }
        }
    }

    void StartObjectPlacement(Vector3 position)
    {
        selectedObject = Instantiate(objectPrefabs[selectedObjectIndex], position, Quaternion.identity);
        isCreatingObject = true;
    }

    void CreateObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            selectedObject.transform.position = hit.point;
        }
    }

    void HandleMouseRelease()
    {
        if (Input.GetMouseButtonUp(0) && isCreatingObject)
        {
            // Lógica para cuando se suelta el clic del mouse durante la creación del objeto
            EndObjectPlacement();
        }
    }

    public void EndObjectPlacement()
    {
        isCreatingObject = false;


    }

    public void SelectObjectToCreate(int objectIndex)
    {
        selectedObjectIndex = objectIndex;


    }

    public void ActivateCreateMode()
    {

    }
}
