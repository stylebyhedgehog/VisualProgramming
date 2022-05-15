using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    [SerializeField] private List<GameObject> undestroyable;
    
    void Start()
    {
        foreach (GameObject go in undestroyable)
        {
            DontDestroyOnLoad(go);
        }
    }
}
