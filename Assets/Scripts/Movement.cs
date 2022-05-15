using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatStopMovement;
 
 
  
    void Start()
    {
        movePoint.parent = null;
        Repository_Level.levelLoaded += setStartPoin;
        DontDestroyOnLoad(movePoint.gameObject);
    }

    private void setStartPoin(Model_Level level)
    {
        gameObject.transform.position = level.StartPosition;
        movePoint.position = gameObject.transform.position;
    }
    public bool isObstacleForward()
    {
        return Physics2D.OverlapCircle(movePoint.position + transform.up, 0.2f, whatStopMovement);
    }

    public bool isObstacleBackward()
    {
        return Physics2D.OverlapCircle(movePoint.position - transform.up, 0.2f, whatStopMovement);
    }

    public bool isObstacleRight()
    {
        return Physics2D.OverlapCircle(movePoint.position + transform.right, 0.2f, whatStopMovement);
    }

    public bool isObstacleLeft()
    {
        return Physics2D.OverlapCircle(movePoint.position - transform.right, 0.2f, whatStopMovement);
    }
   
    public void moveForward()
    {
        if (!isObstacleForward())
        {
            movePoint.position += transform.up;
        }
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, 1);
    }

    public void moveBackward()
    {
        if (!isObstacleBackward())
        {
            movePoint.position -= transform.up;
        }
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, 1);
    }

    public void moveRight()
    {
        if (!isObstacleRight())
        {
            movePoint.position += transform.right;
        }
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, 1);
    }

    public void moveLeft()
    {
        if (!isObstacleLeft())
        {
            movePoint.position -= transform.right;
        }
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, 1);
    }

    
}
