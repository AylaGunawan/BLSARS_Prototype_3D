using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    //[SerializeField] private TMP_Text promptText;
    [SerializeField] private Image interactBar;
    [SerializeField] private float distance = 5f;

    private Camera playerCamera;
    private float interactTimer = 0f;
    private float interactTime = 1f;
    private bool isInteracting = false;

    void Start()
    {
        playerCamera = GetComponent<PlayerControl>().playerCamera;
    }

    void Update()
    {
        //promptText.text = string.Empty;

        // set up raycast
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        // handle raycast
        if (Physics.Raycast(ray, out hit, distance))
        {
            Debug.Log(hit.collider.name);

            if (hit.collider.TryGetComponent<Interaction>(out Interaction interaction))
            {
                //promptText.text = interaction.promptMessage;

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
                    interactTimer = 0;
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
