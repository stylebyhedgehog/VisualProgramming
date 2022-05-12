using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{
    [SerializeField] private Button executeBtn;
    [SerializeField] private Button closeBtn;
    public static Action executeBtnClicked;
    public static Action closeBtnClicked;
    void Start()
    {
        executeBtn.onClick.AddListener(() => executeBtnClickedAction());
        closeBtn.onClick.AddListener(() => closeBtnClickedAction());
    }

    private void executeBtnClickedAction()
    {
        executeBtnClicked?.Invoke();
    }
    private void closeBtnClickedAction()
    {
        gameObject.SetActive(false);
        closeBtnClicked?.Invoke();
    }


}
