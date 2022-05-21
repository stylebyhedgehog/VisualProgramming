using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SignUpPanel : MonoBehaviour
{
    [Header("UI components")]
    [SerializeField] private Text error;
    [SerializeField] private InputField usesrname;
    [SerializeField] private InputField password;
    [SerializeField] private InputField repeatPassword;
    [SerializeField] private Button signUp;
    [SerializeField] private Button toMainMenu;


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
        string result = Controller_Auth.TryToSignUp(usesrname.text, password.text, repeatPassword.text);
        if (result == "Регистрация пройдена")
        {
            ToMainMenu();
        }else
        {
            error.text = result;
        }
        
    }


    private void ToMainMenu()
    {
        error.text = "";
        SceneManager.LoadScene("StartScene");
    }
}
