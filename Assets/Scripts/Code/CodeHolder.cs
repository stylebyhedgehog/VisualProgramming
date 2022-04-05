using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeHolder : MonoBehaviour
{
    [SerializeField] private List<string> actions;
    private GameObject startBlock;

    private void Start()
    {
        actions = new List<string>();
    }
}
