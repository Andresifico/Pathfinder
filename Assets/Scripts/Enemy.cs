using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;
    List<Cell> path;
    [SerializeField]
    private float moveSpeed = 2f;

    private void Awake()
    {
        instance = this;
    }
    public Vector2 GetPosition => transform.position;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetPath(List<Cell> path)
    {
        //ResetPosition();
        waypointIndex = 0;
        path.RemoveAt(0);
        this.path = path;
        
    }

    public void ResetPosition(int x, int y)
    {
        transform.position = new Vector2(x, y);
    }

    private void Move()
    {
        // If player didn't reach last waypoint it can move
        // If player reached last waypoint then it stops
        if (path == null)
            return;

        if (waypointIndex <= path.Count - 1)
        {

            // Move player from current waypoint to the next one
            // using MoveTowards method}
            
            transform.position = Vector2.MoveTowards(transform.position,
               path[waypointIndex].transform.position,
               moveSpeed * Time.deltaTime);
            //transform.position = path[waypointIndex].transform.position;
            //Debug.Log(transform.position);

            // If player reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and player starts to walk to the next waypoint
            if (transform.position == path[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }

    public void Hide()
    {
        transform.position = new Vector2(1000, 1000);
    }
}
