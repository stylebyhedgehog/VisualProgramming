using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance;

    private Model_User currentUser;

    public static Action userLoggedIn;
    public static Action userLoggedOut;

    public static Action<Model_User> userUpdate;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    void Start()
    {
        SetDataOnFirstRun();
        LoadData();

    }


    private void LoadData()
    {
        if (PlayerPrefs.GetInt("isUserRemembered") == 1)
        {
            string username = PlayerPrefs.GetString("username");
            currentUser = Repository_User.GetUserByUsername(username);
            userLoggedIn?.Invoke();
        }
    }

    private void SetDataOnFirstRun()
    {
        if (PlayerPrefs.GetInt("isFirstGameRun", 1) == 1)
        {
            PlayerPrefs.SetInt("isFirstGameRun", 0);
            PlayerPrefs.SetInt("isUserRemembered", 0);
        }
    }


    public void updateUser(Model_User user)
    {
        currentUser = user;
        userUpdate?.Invoke(currentUser);
    }

    public void setCurrentUser(Model_User user, bool rememberUser)
    {
        currentUser = user;
        if (rememberUser)
        {
            PlayerPrefs.SetInt("isUserRemembered", 1);
            PlayerPrefs.SetString("username", currentUser.Username);
        }
        else
        {
            PlayerPrefs.SetInt("isUserRemembered", 0);
        }
       
        userLoggedIn?.Invoke();
    }

    public void removeCurrentUser()
    {
        PlayerPrefs.SetInt("isUserRemembered", 0);
        currentUser = null;
        userLoggedOut?.Invoke();
    }

    public Model_User getCurrentUser()
    {
        return currentUser;
    }

    public bool isUserAuthorized()
    {
        if (PlayerPrefs.GetInt("isUserRemembered") == 1)
        {
            return true;
        }
        return false;
    }

}
