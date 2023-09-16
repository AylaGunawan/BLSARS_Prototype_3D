using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    // public string promptMessage;

    protected StageManagerScript stageManagerScript;

    public void Awake()
    {
        stageManagerScript = GameObject.FindGameObjectWithTag("StageManager").GetComponent<StageManagerScript>();
    }

    public void BaseInteract() // called by PlayerInteract
    {
        Interact();
    }

    protected virtual void Interact() // overriden by child class
    {

    }
}
