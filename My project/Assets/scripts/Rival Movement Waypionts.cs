using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalMovementWaypionts : MonoBehaviour
{
    // Stores a reference to to the waypoint system the object will use
    [SerializeField] private RivalAI waypoints;

    [SerializeField] private float moveSpeed = 10f;

    private Transform currentWaypoint;
    // Start is called before the first frame update
    void Start()
    {
        // Set inital position to the first waypoint
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
