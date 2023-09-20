using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private TMP_Text placeholderText;
    [SerializeField] private Image interactBar;
    [SerializeField] private float distance = 5f;

    private Camera playerCamera;
    private LayerMask interactionMasks;
    private float interactTimer = 0f;
    private float interactTime = 1f;
    private bool isInteracting = false;

    void Start()
    {
        playerCamera = GetComponent<PlayerControl>().playerCamera;
        interactionMasks = LayerMask.GetMask("Danger", "Response", "Send_Help", "Airway", "Breathing", "CPR", "Defib");
    }

    void Update()
    {
        placeholderText.text = string.Empty;

        // set up raycast
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        // handle raycast
        if (Physics.Raycast(ray, out hit, distance, interactionMasks))
        {
            // handle collision with interaction
            if (hit.collider.TryGetComponent<Interaction>(out Interaction interaction))
            {
                placeholderText.text = interaction.placeholderMessage;

                // handle interact
                if (Input.GetKey(KeyCode.Space))
                {
                    isInteracting = true;
                }
                else
                {
                    isInteracting = false;
                }

                if (interactTimer >= interactTime) // when interact is done
                {
                    interaction.BaseInteract();
                    isInteracting = false;
                }
            }
        }
        else
        {
            isInteracting = false;
        }

        // handle interact bar
        if (isInteracting)
        {
            interactTimer += Time.deltaTime;
        }
        else
        {
            interactTimer = 0;
        }
        interactBar.fillAmount = interactTimer / interactTime;
    }
}
