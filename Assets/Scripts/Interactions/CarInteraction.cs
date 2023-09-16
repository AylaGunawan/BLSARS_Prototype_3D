using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInteraction : Interaction
{
    void Start()
    {
        // position car
    }

    void Update()
    {
        // move car
    }

    protected override void Interact()
    {
        base.Interact();

        stageManagerScript.interactionObjects.Add(gameObject);
        gameObject.SetActive(false);
    }
}
