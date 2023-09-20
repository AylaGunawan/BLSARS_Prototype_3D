using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarInteraction : Interaction
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private float minDistance = 1f;

    private int currentWaypoint = 0;

    void Start()
    {
        // position car
    }

    void Update()
    {
        // handle current waypoint
        if (Vector3.Distance(this.transform.position, waypoints[currentWaypoint].transform.position) < minDistance) {
            currentWaypoint++;
        }

        if (currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0;
        }

        // handle rotate
        Quaternion rotationToWaypoint = Quaternion.LookRotation(waypoints[currentWaypoint].transform.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotationToWaypoint, rotateSpeed * Time.deltaTime);

        // handle move
        this.transform.Translate(0, 0, moveSpeed * Time.deltaTime);
    }

    protected override void Interact()
    {
        base.Interact();

        stageManagerScript.interactionObjects.Add(gameObject);
        gameObject.SetActive(false);
    }
}
