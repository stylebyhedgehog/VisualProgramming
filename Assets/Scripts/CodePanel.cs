using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{
    [SerializeField] private Button closeBtn;
    public static Action closeBtnClicked;
    void Start()
    {
        closeBtn.onClick.AddListener(() => closeBtnClickedAction());
    }

    private void closeBtnClickedAction()
    {
        closeBtnClicked?.Invoke();
        //gameObject.SetActive(false);

    }


}
