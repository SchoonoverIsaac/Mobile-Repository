using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalMovementWaypionts : MonoBehaviour
{
    // Stores a reference to to the waypoint system the object will use
    [SerializeField] private RivalAI waypoints;

    [SerializeField] private float moveSpeed = 10f;

    [SerializeField] private float distanceThreshold = 0.1f;

    // The current wwaypoint target that the object  is moving towards
    private Transform currentWaypoint;


    // Start is called before the first frame update
    void Start()
    {
        // Set inital position to the first waypoint
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        // Set the next waypoint target
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed* Time.deltaTime);
      if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
            transform.LookAt(currentWaypoint);
        }
    }
}
