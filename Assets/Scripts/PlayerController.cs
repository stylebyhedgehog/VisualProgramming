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

    public void rotateR()
    {
        movement.rotateRight();
    }

    public void rotateL ()
    {
        movement.rotateLeft();
    }
}
