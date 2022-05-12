using MongoDB.Bson;
using UnityEngine;

public class Model_Level
{
    public Model_Level(int index, string title, string theory, Vector3 startPosition = default)
    {
        Index = index;
        Title = title;
        Theory = theory;
        StartPosition = startPosition;
    }

    public int Index { private set; get; }
    public string Title { private set; get; }
    public string Theory { private set; get; }
    public Vector3 StartPosition { private set; get; }
}
