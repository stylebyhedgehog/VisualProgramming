using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatStopMovement;
 
    private void OnLevelWasLoaded(int level)
    {
        gameObject.transform.position = Repository_Level.Instance.GetByIndex(level).StartPosition;
        movePoint.position = gameObject.transform.position;
    }

  
    void Start()
    {
        movePoint.parent = null;
        DontDestroyOnLoad(movePoint.gameObject);
    }

    public void rotateRight()
    {
        transform.Rotate(new Vector3(0,0,-90) , Space.World);
    }
    public void rotateLeft ()
    {
        transform.Rotate(new Vector3(0, 0, 90), Space.World);
    }
    public void moveForward()
    {
        if (!Physics2D.OverlapCircle(movePoint.position + transform.up, 0.2f, whatStopMovement))
        {
            movePoint.position += transform.up;
        }
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position,1) ;
    }

    public void moveBackward()
    {
        if (!Physics2D.OverlapCircle(movePoint.position - transform.up, 0.2f, whatStopMovement))
        {
            movePoint.position -= transform.up;
        }
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, 1);
    }
    /*void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movementSpeed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
           
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f, whatStopMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }
            else
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.2f, whatStopMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }
        }
    }*/
}
