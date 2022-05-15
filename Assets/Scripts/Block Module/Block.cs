using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Block
{
    public Block_Type_Action type;
    public GameObject go;
    private bool isAvailable = false;

    public void Show()
    {
        if (isAvailable)
        {
            go.SetActive(true);
        }
    }

    public void Hide()
    {
         go.SetActive(false);
    }

    public void makeAvailable()
    {
        isAvailable = true;
    }

    public void makeUnavailable()
    {
        isAvailable = false;
    }

    /*    public bool isBlockAvailable()
        {
            return isAvailable;
        }*/
}
