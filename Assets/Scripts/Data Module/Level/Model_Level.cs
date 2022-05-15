using MongoDB.Bson;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level")]
public class Model_Level:ScriptableObject
{
    public int Index;
    public string Title;
    public string Theory;
    public Vector3 StartPosition;
    public int Reward;
    public bool IsAvailable;
    public List<Block_Type_Action> newBlocks;
}
