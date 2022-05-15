using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] private Movement movement;

    private void Awake()
    {
        Instance = this;
    }

    public void moveF()
    {
        movement.moveForward();
    }

    public void moveB()
    {
        movement.moveBackward();
    }

    public void moveR()
    {
        movement.moveRight();
    }

    public void moveL ()
    {
        movement.moveLeft();
    }

    public bool isObstacleForward()
    {
        return movement.isObstacleForward();
    }

    public bool isObstacleBackward()
    {
        return movement.isObstacleBackward();
    }

    public bool isObstacleRight()
    {
        return movement.isObstacleRight();
    }

    public bool isObstacleLeft()
    {
        return movement.isObstacleLeft();
    }
}
