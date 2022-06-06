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
    
    [SerializeField] private GameObject navigationUi;
   

    void Start()
    {
        executeBtn.onClick.AddListener(() => executeBtnClickedAction());
        closeBtn.onClick.AddListener(() => closeBtnClickedAction());
    }

    private void executeBtnClickedAction()
    {
        Execution.Instance.startExecution();
    }
    private void closeBtnClickedAction()
    {
        navigationUi.SetActive(true);
        gameObject.SetActive(false);
        closeBtnClicked?.Invoke();
    }


}
