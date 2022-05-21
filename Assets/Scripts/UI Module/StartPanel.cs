using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartPanel : MonoBehaviour
{
    [SerializeField] private Button logInBtn;
    void Start()
    {
        Controller_Local.SetDataOnFirstRun();
        if (Controller_Local.IsUserAuthorized() && Controller_Local.IsUserRemembered())
        {
            Authed();
        } else
        {
            NotAuthed();

        }
    }

    private void Authed()
    {
        Model_User user = Controller_User.GetCurrentUser();
        Controller_Auth.TryToLogIn(user.Username, Cryptography.Decrypt(user.Password), true);
        SceneManager.LoadScene("MainMenu");
    }

    private void NotAuthed()
    {
        logInBtn.onClick.AddListener(() => ChangeScene());
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("LogInScene");
    }

    private void OnApplicationQuit()
    {
        if (!Controller_Local.IsUserRemembered())
        {
            Controller_Local.RemoveSavedUserAndForget();
        }
    }
}
