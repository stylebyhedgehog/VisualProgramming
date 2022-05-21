using MongoDB.Bson;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Levels")]
public class Model_Level:ScriptableObject
{
    public int Index;
    public string Title;
    public List<Model_Theory> Theory;
    public int Reward;
    public List<Block_Type_Action> availableBlocks;
    public List<Block_Type_Purpose> requiredBlocks;
    public Vector3 StartPosition;
    public string SceneName;
}
