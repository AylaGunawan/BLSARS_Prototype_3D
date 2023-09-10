using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    private Camera playerCamera;

    [SerializeField] private TMP_Text promptText;
    [SerializeField] private float distance = 3f; // different distances for different interactions?

    void Start()
    {
        playerCamera = GetComponent<PlayerController>().playerCamera;
    }

    void Update()
    {
        // do stuff before raycast
        promptText.text = string.Empty;

        // shoot forward ray from cam
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, distance))
        {
            // do stuff after raycast
            if (hit.collider.TryGetComponent<Interaction>(out Interaction interaction))
            {
                promptText.text = interaction.promptMessage;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    interaction.BaseInteract();
                }
            }
        }
    }
}
