using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdDatabase : MonoBehaviour
{
    public static IdDatabase Instance;
    public int id;

    private void Awake()
    {
        Instance = this;
        id = 0;
    }

    public int getId()
    {
        id += 1;
        return id;
    }
   

}
