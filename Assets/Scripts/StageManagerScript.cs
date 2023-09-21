using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StageManagerScript : MonoBehaviour
{
    public List<GameObject> interactionObjects = new List<GameObject>();

    [SerializeField] private List<GameObject> evaluationObjects = new List<GameObject>();
    [SerializeField] private GameObject evaluationUI;
    [SerializeField] private GameObject evaluationPrefab;
    [SerializeField] private GameObject evaluationParent;

    private float time = 0; // in seconds
    private bool isRunning;

    //private bool dangerCorrect = false;
    //private bool responseCorrect = false;
    //private bool sendHelpCorrect = false;
    //private bool airwayCorrect = false;
    //private bool breathingCorrect = false;
    //private bool cprCorrect = false;
    //private bool defibCorrect = false;

    void Start()
    {
        isRunning = true;
        evaluationUI.SetActive(false);
    }

    void Update()
    {
        // handle countdown (change to timer?)
        if (isRunning)
        {
            time += Time.deltaTime;
        }

        // debug evaluate
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("evaluated at " + time);
            time = 0;

            Evaluate();
        }
    }

    public void Evaluate()
    {
        // unhide evaluation ui
        evaluationUI.SetActive(true);

        // add placeholders until the number of items in a phase is equal between interaction and evaluation
        while (evaluationObjects.Count > interactionObjects.Count)
        {
            interactionObjects.Add(new GameObject(name: "placeholder"));
        }

        while (evaluationObjects.Count < interactionObjects.Count)
        {
            evaluationObjects.Add(new GameObject(name: "placeholder"));
        }

        for (int i = 0; i < evaluationObjects.Count; i++)
        {
            Debug.Log(i);

            if (evaluationObjects[i].name == "placeholder")
            {
                Debug.Log("placeholder skipped");
                continue;
            }

            // item in interactions is correct and in order
            if (evaluationObjects[i] == interactionObjects[i])
            {
                Instantiate(evaluationPrefab, evaluationParent.transform);
                Debug.Log("item in interactions is correct and in order");
            }
            // item in interactions is correct but not in order
            else if (interactionObjects.Contains(evaluationObjects[i])) {
                Instantiate(evaluationPrefab, evaluationParent.transform);
                Debug.Log("item in interactions is correct but not in order");
            }
            // item in interactions is incorrect (not in evaluation) and not a placeholder
            else if (!evaluationObjects.Contains(interactionObjects[i]) && interactionObjects[i].name != "placeholder") {
                Instantiate(evaluationPrefab, evaluationParent.transform);
                Debug.Log("item in interactions is incorrect (not in evaluation) and not a placeholder");
            }
            // item is missing (not in interactions)
            else
            {
                Instantiate(evaluationPrefab, evaluationParent.transform);
                Debug.Log("item is missing (not in interactions)");
            }
        }
    }

    //    private void UpdatePhases(int index)
    //    {
    //        switch (index)
    //        {
    //            case 0: // danger
    //                dangerCorrect = true;
    //                break;
    //            case 1: // response
    //                responseCorrect = true;
    //                break;
    //            case 2: // send help
    //                sendHelpCorrect = true;
    //                break;
    //            case 3: // airway
    //                airwayCorrect = true;
    //                break;
    //            case 4: // breathing
    //                breathingCorrect = true;
    //                break;
    //            case 5: // cpr
    //                cprCorrect = true;
    //                break;
    //            case 6: // defib
    //                defibCorrect = true;
    //                break;
    //            default:
    //                break;
    //        }
    //    }

    //    private List<List<GameObject>> SortPhases(List<GameObject> objs)
    //    {
    //        // set up temporary lists
    //        List<GameObject> dangerObjects = new List<GameObject>();
    //        List<GameObject> responseObjects = new List<GameObject>();
    //        List<GameObject> sendHelpObjects = new List<GameObject>();
    //        List<GameObject> airwayObjects = new List<GameObject>();
    //        List<GameObject> breathingObjects = new List<GameObject>();
    //        List<GameObject> cprObjects = new List<GameObject>();
    //        List<GameObject> defibObjects = new List<GameObject>();

    //        // sort input list into temporary lists
    //        foreach (GameObject obj in objs)
    //        {
    //            switch (obj.layer)
    //            {
    //                case 6:
    //                    dangerObjects.Add(obj);
    //                    break;
    //                case 7:
    //                    responseObjects.Add(obj);
    //                    break;
    //                case 8:
    //                    sendHelpObjects.Add(obj);
    //                    break;
    //                case 9:
    //                    airwayObjects.Add(obj);
    //                    break;
    //                case 10:
    //                    breathingObjects.Add(obj);
    //                    break;
    //                case 11:
    //                    cprObjects.Add(obj);
    //                    break;
    //                case 12:
    //                    defibObjects.Add(obj);
    //                    break;
    //                default:
    //                    break;
    //            }
    //        }

    //        // sort temporary lists where order is not important
    //        //dangerObjects.Sort();
    //        //sendHelpObjects.Sort();
    //        //breathingObjects.Sort();

    //        return new List<List<GameObject>> { dangerObjects, responseObjects, sendHelpObjects, airwayObjects, breathingObjects, cprObjects, defibObjects };
    //    }
}
