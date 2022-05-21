using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        string result = Controller_Auth.TryToLogIn(usesrname.text, password.text, rememberMe.isOn);
        if (result == "Авторизация пройдена")
        {
            ToMainMenu();
        } else
        {
            error.text = result;
        }
    }

    private void ToSignUp()
    {
        error.text = "";
        SceneManager.LoadScene("SignUpScene");
    }

    private void ToMainMenu()
    {
        error.text = "";
        SceneManager.LoadScene("StartScene");
    }
}
