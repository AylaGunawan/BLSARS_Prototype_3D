using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private LayerMask mask;
    [SerializeField] private TMP_Text promptText;

    [SerializeField] private float distance = 3f;

    void Start()
    {

    }

    void Update()
    {
        promptText.text = string.Empty;

        // shoot a forward ray from cam centre
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hitInfo;
        Debug.DrawRay(ray.origin, ray.direction * distance);
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null) // try get component instead?
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                promptText.text = interactable.promptMessage;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
