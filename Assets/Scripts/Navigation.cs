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
    }

    private void InitButtons()
    {
        openCodePanelBtn.onClick.AddListener(()=>codePanel.SetActive(true));
    }
}
