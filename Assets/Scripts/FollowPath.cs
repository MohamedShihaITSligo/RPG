using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour {

    public NavigationPath path;
    public bool PickRandomStartNode = false;
    public bool canMove = true;
    public float moveSpeed = 2f;
    public float distanceToNodeTolerance = 0.2f;

    Vector2 currentTarget;
    Rigidbody2D body;
    int currentNodeIndex = 0;
    //StopBox stopBox;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        if (PickRandomStartNode)
        {
            currentNodeIndex = Random.Range(0, path.NodeCount - 1);
        }
        GetNextNodePosition();
        TeleportToNode();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position , currentTarget) <= distanceToNodeTolerance)
        {
            GetNextNodePosition();
        }
        
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            body.MovePosition(Vector2.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime));
        }
        body.angularVelocity = 0;
    }

    void TeleportToNode()
    {
        transform.position = currentTarget;
    }

    void GetNextNodePosition()
    {
        if (currentNodeIndex >= path.NodeCount) currentNodeIndex = 0;
        currentTarget = path.GetNodePosition(currentNodeIndex);
        transform.up = currentTarget - body.position;
        currentNodeIndex++;
    }


}
