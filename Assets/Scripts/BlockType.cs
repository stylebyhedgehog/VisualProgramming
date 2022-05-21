using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockType : MonoBehaviour
{
    public Block_Type_Composition compisitionType;
    public Block_Type_Purpose purposeType;
}
public enum Block_Type_Composition
{
    Basic,
    Condition_Start,
    Condition_Middle,
    Condition_Completion
}

public enum Block_Type_Purpose
{
    Start_Script,
    Movement,
    Cycle,
    Condition
}

public enum Block_Type_Action
{
    Start_Script,
    Move_Forward,
    Move_Backward, 
    Move_Left,
    Move_Right,
    Cycle,
    Condition,
    Direction_Forward,
    Direction_Backward,
    Direction_Left,
    Direction_Right,
    Check_Obstacle
}