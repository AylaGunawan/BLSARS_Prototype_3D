using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInteraction : Interaction // or DangerInteraction
{
    void Start()
    {
        layer = gameObject.layer;
        phase = layer.ToString();
    }

    void Update()
    {
    }

    protected override void Interact()
    {
        base.Interact();

        stageManagerScript.interactionObjs.Add(gameObject);
        gameObject.SetActive(false);
    }
}
