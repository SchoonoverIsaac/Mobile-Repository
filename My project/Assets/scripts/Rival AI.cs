using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalAI : MonoBehaviour
{
    [Range(0f,2f)]
    [SerializeField] private float WayPointSize = 1f;

    [Header("Path Settings")]
    // Sets the path to be looped so agent will go form the last waypoint to the first or vice versa
    [SerializeField] private bool canLoop = true;
    private void OnDrawGizmos()
    {
        foreach (Transform t in transform)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(t.position, 1f);
        }
        Gizmos.color = Color.red;  
        for(int i = 0; i < transform.childCount - 1; i++)
        {
          Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }

        // If the path is set to loop then draw a line between the last and first waypoint
        if (canLoop)
        {
            Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position, transform.GetChild(0).position);
        }

       
    }

    // will get the correct next waypoint based on the direction currently travelling
    public Transform GetNextWaypoint(Transform currentWaypoint)
    {
        if (currentWaypoint == null) 
        {
            return transform.GetChild(0);
        }

       if (currentWaypoint.GetSiblingIndex() < transform.childCount-1)
        {
           return transform.GetChild(currentWaypoint.GetSiblingIndex() + 1);
        }
       else
        {
            if (canLoop)
            {
                return transform.GetChild(0);
            }
            else 
            { 
              return transform.GetChild(currentWaypoint.GetSiblingIndex());
            }
        }
    }   
}
