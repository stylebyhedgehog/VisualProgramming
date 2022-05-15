using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignUpPanel : MonoBehaviour
{
    [Header("UI components")]
    [SerializeField] private Text error;
    [SerializeField] private InputField usesrname;
    [SerializeField] private InputField password;
    [SerializeField] private InputField repeatPassword;
    [SerializeField] private Button signUp;
    [SerializeField] private Button toMainMenu;

    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;

    void Start()
    {
        error.text = "";
        InitializeButtonActions();
    }


    private void InitializeButtonActions()
    {
        signUp.onClick.AddListener(() => SignUp());
        toMainMenu.onClick.AddListener(() => ToMainMenu());
    }

    private void SignUp()
    {
        error.text = "";
        Authentication_Result result = Service_Auth.SignUp(usesrname.text, password.text, repeatPassword.text);
        switch (result)
        {
            case (Authentication_Result.SUCCESS_SIGN_UP):
                ToMainMenu();
                break;
            case (Authentication_Result.ERROR_SIGN_UP_EXISTS):
                error.text = "Логин занят";
                break;
            case (Authentication_Result.ERROR_SIGN_UP_LENGTH):
                error.text = "Логин и пароль должны быть больше 6 символов";
                break;
            case (Authentication_Result.ERROR_SIGN_UP_PASSWORD_MATCHING):
                error.text = "Пароли не совпадают";
                break;
            case (Authentication_Result.ERROR_SIGN_UP_DATABASE):
                error.text = "Попробуйте еще раз";
                break;
            default:
                break;
        }
        
    }


    private void ToMainMenu()
    {
        error.text = "";
        gameObject.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
