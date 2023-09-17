using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Phase { Danger, Response, Send_Help, Airway, Breathing, CPR, Defib }

public class StageManagerScript : MonoBehaviour
{
    public List<GameObject> interactionObjects = new List<GameObject>();

    [SerializeField] private List<GameObject> evaluationObjects = new List<GameObject>();

    private List<GameObject> dangerObjects = new List<GameObject>();
    private List<GameObject> responseObjects = new List<GameObject>();
    private List<GameObject> sendHelpObjects = new List<GameObject>();
    private List<GameObject> airwayObjects = new List<GameObject>();
    private List<GameObject> breathingObjects = new List<GameObject>();
    private List<GameObject> cprObjects = new List<GameObject>();
    private List<GameObject> defibObjects = new List<GameObject>();

    private Phase currentPhase = Phase.Danger;
    private Phase lastPhase = Phase.Danger;

    // check if list length equal
    // check if list order equal
    // then check smaller sublists (2 dangers, order not impo)

    // keyword recog for response
    // animator fsm for victim
    // camera cutscene transition for cpr (minigame)
    // countdown timer for stage manager

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Evaluate();
        }
    }

    private void Evaluate()
    {
        LayerMask layer;
        foreach (GameObject obj in interactionObjects)
        {
            layer = obj.layer;

            switch (layer)
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
    }

    public Phase GetCurrentPhase()
    {
        return currentPhase;
    }

    public void ChangePhase() // if player interacts with an object of the next phase, the phase changes to match. if player interacts with all required objects of a phase, the phase changes. then can the player with objects of previous phases? furthermore, they can 
    {
        if (currentPhase != Phase.Defib)
        {
            currentPhase += 1;
            lastPhase = currentPhase - 1;
        }
    }
}
