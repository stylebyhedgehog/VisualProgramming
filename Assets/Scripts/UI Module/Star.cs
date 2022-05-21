using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] private GameObject inner;
    
    public void fillStar()
    {
        inner.SetActive(true);
    }
}
