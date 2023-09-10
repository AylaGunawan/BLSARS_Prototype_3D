using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    // variables that all Interactions share
    public string promptMessage;
    public StageManagerScript stageManagerScript;

    // called by PlayerInteract
    public void BaseInteract()
    {
        Interact();
    }

    // template function for subclass override
    protected virtual void Interact()
    {
        // do Interact stuff
    }
}
