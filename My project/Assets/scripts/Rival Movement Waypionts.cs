using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalMovementWaypionts : MonoBehaviour
{
    // Stores a reference to to the waypoint system the object will use
    [SerializeField] private RivalAI waypoints;

    [SerializeField] private float moveSpeed = 10f;

    [Range(0f, 20f)] // How fast the agent will rotate once it reaces tits waypoint
    [SerializeField] private float rotateSpeed = 3f;

    [SerializeField] private float distanceThreshold = 0.1f;

    // The current wwaypoint target that the object  is moving towards
    private Transform currentWaypoint;


    // The rotation target fot the current frame
    private Quaternion rotationGoal;
    // The direction to th next waypoint that the agent need to roatate towards
    private Vector3 directionToWaypoint;


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
            //transform.LookAt(currentWaypoint);
        }
        RotateTowardsWaypoint();
    }

    // Will slowly rotate the agent towards the current waypoint it is moving towards
    private void RotateTowardsWaypoint()
    {
        directionToWaypoint = (currentWaypoint.position - transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(directionToWaypoint);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
    }

}
