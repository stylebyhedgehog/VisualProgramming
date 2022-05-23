using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.12f;
    public Vector3 offset;

    private bool canFollow = false;


    private void OnLevelWasLoaded(int level)
    {
        Execution.executionEnded -= DisableFollowing;
        Execution.executionStarted -= EnableFollowing;
        Execution.executionEnded += DisableFollowing;
        Execution.executionStarted += EnableFollowing;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        ChangePosition();
    }

    private void DisableFollowing()
    {
        canFollow = false;
    }

    private void EnableFollowing()
    {
        canFollow = true;
    }

    private void ChangePosition()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        smoothedPosition.z = -12;
        transform.position = smoothedPosition;
    }


    private void FixedUpdate()
    {
        if (canFollow)
        {
            ChangePosition();
        }
    }
}
