using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string promptMessage;

    // called by PlayerInteract
    public void BaseInteract()
    {
        Interact();
    }

    // template for subclass override
    protected virtual void Interact()
    {

    }
}
