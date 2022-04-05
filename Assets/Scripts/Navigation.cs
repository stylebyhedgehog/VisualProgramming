using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Navigation : MonoBehaviour
{
    [SerializeField] private Button openCodePanelBtn;
    [SerializeField] private GameObject codePanel;
    void Start()
    {
        InitButtons();
        CodePanel.closeBtnClicked += showCodePanelButton;
    }

    private void InitButtons()
    {
        openCodePanelBtn.onClick.AddListener(()=>onCodePanelButtonClicked());
    }
    
    private void onCodePanelButtonClicked()
    {
        codePanel.SetActive(true);
        openCodePanelBtn.gameObject.SetActive(false);
    }

    private void showCodePanelButton()
    {
        openCodePanelBtn.gameObject.SetActive(true);
    }
}
