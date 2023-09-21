using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefibrillatorInteraction : Interaction
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

        // use defib, evaluate
        stageManagerScript.Evaluate();
    }
}
