using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StageManagerScript : MonoBehaviour
{
    public List<GameObject> interactionObjects = new List<GameObject>();

    [SerializeField] private List<GameObject> evaluationObjects = new List<GameObject>();
    [SerializeField] private GameObject playerUI;
    [SerializeField] private GameObject evaluationUI;
    [SerializeField] private GameObject evaluationPrefab;
    [SerializeField] private GameObject evaluationParent;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private string menuScene = "MenuScene";

    private List<GameObject> paddedInteractionObjects = new List<GameObject>();
    private List<GameObject> paddedEvaluationObjects = new List<GameObject>();
    private float timer = 0; // in seconds
    private bool timerIsRunning;

    private const string PLACEHOLDER_NAME = "placeholder";

    void Start()
    {
        // hide/unhide ui
        playerUI.SetActive(true);
        evaluationUI.SetActive(false);

        // handle time
        timerIsRunning = true;
        Time.timeScale = 1;
    }

    void Update()
    {
        // handle timer
        if (timerIsRunning)
        {
            timer += Time.deltaTime;
        }

        // for debugging evaluate
        if (Input.GetKeyDown(KeyCode.E))
        {
            Evaluate();
        }
    }

    public void Evaluate()
    {
        // handle cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // hide/unhide ui
        playerUI.SetActive(false);
        evaluationUI.SetActive(true);

        // handle time
        timerIsRunning = false;
        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);
        timeText.text = $"Time taken:\n{minutes:00}:{seconds:00}";
        Time.timeScale = 0;

        // sort interactions and evaluations into phases
        List<List<GameObject>> interactionPhases = SortObjectsIntoPhases(interactionObjects);
        List<List<GameObject>> evaluationPhases = SortObjectsIntoPhases(evaluationObjects);

        // pad phases with placeholders until the number of items in each phase is equal between interaction and evaluation
        for (int phaseIndex = 0; phaseIndex < evaluationPhases.Count; phaseIndex++)
        {
            while (evaluationPhases[phaseIndex].Count > interactionPhases[phaseIndex].Count)
            {
                interactionPhases[phaseIndex].Add(new GameObject(name:PLACEHOLDER_NAME));
            }

            while (evaluationPhases[phaseIndex].Count < interactionPhases[phaseIndex].Count)
            {
                evaluationPhases[phaseIndex].Add(new GameObject(name:PLACEHOLDER_NAME));
            }
        }

        // restructure padded interactions and evaluations with phases and placeholders
        foreach (List<GameObject> phase in interactionPhases)
        {
            foreach (GameObject obj in phase)
            {
                paddedInteractionObjects.Add(obj);
            }
        }
        foreach (List<GameObject> phase in evaluationPhases)
        {
            foreach (GameObject obj in phase)
            {
                paddedEvaluationObjects.Add(obj);
            }
        }

        for (int i = 0; i < paddedInteractionObjects.Count; i++)
        {
            GameObject clone = Instantiate(evaluationPrefab, evaluationParent.transform);
            Color cloneColor;

            // item in interactions is correct and in order
            if (paddedInteractionObjects[i] == paddedEvaluationObjects[i])
            {
                cloneColor = Color.green;
                clone.gameObject.GetComponentInChildren<TMP_Text>().text = LayerMask.LayerToName(paddedInteractionObjects[i].gameObject.layer) + ": " + paddedInteractionObjects[i].gameObject.GetComponent<Interaction>().evaluateMessage;
            }
            // if the item in interactions is incorrect (not in evaluation) and not a placeholder
            else if (!paddedEvaluationObjects.Contains(paddedInteractionObjects[i]) && paddedInteractionObjects[i].name != PLACEHOLDER_NAME)
            {
                cloneColor = Color.red;
                clone.gameObject.GetComponentInChildren<TMP_Text>().text = LayerMask.LayerToName(paddedInteractionObjects[i].gameObject.layer) + ": " + paddedInteractionObjects[i].gameObject.GetComponent<Interaction>().evaluateMessage + "\nIncorrect interaction";
            }
            // if the item in interactions is correct but not in order (does not include phase order)
            else if (paddedInteractionObjects.Contains(paddedEvaluationObjects[i])) {
                cloneColor = Color.yellow;
                clone.gameObject.GetComponentInChildren<TMP_Text>().text = LayerMask.LayerToName(paddedInteractionObjects[i].gameObject.layer) + ": " + paddedInteractionObjects[i].gameObject.GetComponent<Interaction>().evaluateMessage + "\nIncorrect order";
            }
            // if the item in evaluations is not a placeholder
            else if (paddedEvaluationObjects[i].name == "placeholder")
            {
                continue;
            }
            // if the item is missing (not in interactions)
            else
            {
                cloneColor = Color.grey;
                clone.gameObject.GetComponentInChildren<TMP_Text>().text = LayerMask.LayerToName(paddedEvaluationObjects[i].gameObject.layer) + ": " + paddedEvaluationObjects[i].gameObject.GetComponent<Interaction>().evaluateMessage + "\nMissing interaction";
            }

            clone.gameObject.GetComponentInChildren<Image>().color = cloneColor;
        }
    }

        private List<List<GameObject>> SortObjectsIntoPhases(List<GameObject> objs)
    {
        // set up temporary lists
        List<GameObject> dangerObjects = new List<GameObject>();
        List<GameObject> responseObjects = new List<GameObject>();
        List<GameObject> sendHelpObjects = new List<GameObject>();
        List<GameObject> airwayObjects = new List<GameObject>();
        List<GameObject> breathingObjects = new List<GameObject>();
        List<GameObject> cprObjects = new List<GameObject>();
        List<GameObject> defibObjects = new List<GameObject>();

        // sort input list into temporary lists
        foreach (GameObject obj in objs)
        {
            switch (obj.layer)
            {
                case 6:
                    dangerObjects.Add(obj);
                    break;
                case 7:
                    responseObjects.Add(obj);
                    break;
                case 8:
                    sendHelpObjects.Add(obj);
                    break;
                case 9:
                    airwayObjects.Add(obj);
                    break;
                case 10:
                    breathingObjects.Add(obj);
                    break;
                case 11:
                    cprObjects.Add(obj);
                    break;
                case 12:
                    defibObjects.Add(obj);
                    break;
                default:
                    break;
            }
        }

        return new List<List<GameObject>> { dangerObjects, responseObjects, sendHelpObjects, airwayObjects, breathingObjects, cprObjects, defibObjects };
    }

    // menu start functions

    public void onMenuStart()
    {
        Debug.Log("onMenuStart");

        SceneManager.LoadScene(menuScene);
    }
}
