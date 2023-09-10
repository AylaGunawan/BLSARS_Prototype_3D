using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInteraction : Interaction // or DangerInteraction
{
    // variables that all Cars share

    void Start()
    {
        // do Car stuff
        stageManagerScript = GameObject.FindGameObjectWithTag("StageManager").GetComponent<StageManagerScript>();
        Debug.Log(stageManagerScript);
    }

    void Update()
    {
        // do Car stuff
    }

    protected override void Interact()
    {
        base.Interact();

        // do Car stuff
        stageManagerScript.gameObjects.Add(gameObject);

        Debug.Log("Interacted with " + gameObject.name);
        string s = "";
        foreach (GameObject gameObject in stageManagerScript.gameObjects)
        {
            s = string.Concat(s, gameObject.name);
            Debug.Log(s);
        }
    }
}
