using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerInteraction : Interaction
{
    // variables that all Dangers share

    void Start()
    {
        // do Danger stuff
    }

    void Update()
    {
        // do Danger stuff
    }

    protected override void Interact()
    {
        base.Interact();

        // do Danger stuff
        Debug.Log("Danger");
    }
}
