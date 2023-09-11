using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    //public string promptMessage;

    protected StageManagerScript stageManagerScript;
    protected LayerMask layer;
    protected string phase;

    public void Awake()
    {
        stageManagerScript = GameObject.FindGameObjectWithTag("StageManager").GetComponent<StageManagerScript>();
    }

    // called by PlayerInteract
    public void BaseInteract()
    {
        Interact();
    }

    // template function for subclass override
    protected virtual void Interact()
    {

    }
}
