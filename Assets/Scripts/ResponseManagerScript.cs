using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResponseManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject responseC;
    [SerializeField] private GameObject responseO;
    [SerializeField] private GameObject responseW;
    [SerializeField] private GameObject responseS;
    [SerializeField] private TMP_Text responseText;

    private StageManagerScript stageManagerScript;
    private bool responseCDone = false;
    private bool responseODone = false;
    private bool responseWDone = false;
    private bool responseSDone = false;
    private bool inResponseRange = false;


    public void Awake()
    {
        stageManagerScript = GameObject.FindGameObjectWithTag("StageManager").GetComponent<StageManagerScript>();
    }

    void Start()
    {
        responseText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (inResponseRange)
        {
            // handle key presses
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) // O
            {
                stageManagerScript.interactionObjects.Add(responseO.gameObject);
                responseO.gameObject.SetActive(false);
                responseODone = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) // S
            {
                stageManagerScript.interactionObjects.Add(responseS.gameObject);
                responseS.gameObject.SetActive(false);
                responseSDone = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) // W
            {
                stageManagerScript.interactionObjects.Add(responseW.gameObject);
                responseW.gameObject.SetActive(false);
                responseWDone = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)) // C
            {
                stageManagerScript.interactionObjects.Add(responseC.gameObject);
                responseC.gameObject.SetActive(false);
                responseCDone = true;
            }
        }

        // handle all responses done
        if (responseCDone && responseODone && responseWDone && responseSDone)
        {
            gameObject.SetActive(false);
            responseText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inResponseRange = true;
            responseText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inResponseRange = false;
            responseText.gameObject.SetActive(false);
        }
    }
}
