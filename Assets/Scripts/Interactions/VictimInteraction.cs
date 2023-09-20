using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimInteraction : Interaction
{
    void Start()
    {
        // 
    }

    void Update()
    {
        //
    }

    protected override void Interact()
    {
        base.Interact();

        stageManagerScript.interactionObjects.Add(gameObject);
        gameObject.SetActive(false);

        // move victim
    }
}
