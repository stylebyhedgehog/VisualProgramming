using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogInPanel : MonoBehaviour
{
    [Header("UI components")]
    [SerializeField] private Text error;
    [SerializeField] private InputField usesrname;
    [SerializeField] private InputField password;
    [SerializeField] private Toggle rememberMe;
    [SerializeField] private Button logIn;
    [SerializeField] private Button toSignUp;
    [SerializeField] private Button toMainMenu;

    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject signUpPanel;

    void Start()
    {
        error.text = "";
        InitializeButtonActions();
    }


    private void InitializeButtonActions()
    {
        logIn.onClick.AddListener(() => LogIn());
        toSignUp.onClick.AddListener(() => ToSignUp());
        toMainMenu.onClick.AddListener(() => ToMainMenu());
    }
  
    private void LogIn()
    {
        error.text = "";
        Authentication_Result result = Service_Auth.LogIn(usesrname.text, password.text, rememberMe.isOn);
        switch (result)
        {
            case (Authentication_Result.SUCCESS_LOG_IN):
                ToMainMenu();
                break;
            case (Authentication_Result.ERROR_LOG_IN_INCORRECT_DATA):
                error.text = "Неправильные данные";
                break;
            default:
                break;
        }
    }

    private void ToSignUp()
    {
        error.text = "";
        gameObject.SetActive(false);
        signUpPanel.SetActive(true);
    }

    private void ToMainMenu()
    {
        error.text = "";
        gameObject.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
