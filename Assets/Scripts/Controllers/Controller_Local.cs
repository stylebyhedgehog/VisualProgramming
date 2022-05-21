using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Local 
{
    public static void SaveUserAndRemember(string username)
    {
        string encryptedUsername = Cryptography.Encrypt(username);
        Repository_Local.SetUserToken(encryptedUsername);
        Repository_Local.SetIsUserRemembered(1);
    }

    public static void SaveUserAndForget(string username)
    {
        string encryptedUsername = Cryptography.Encrypt(username);
        Repository_Local.SetUserToken(encryptedUsername);
        Repository_Local.SetIsUserRemembered(0);
    }

    public static string GetSavedUserUsername()
    {
        if (Repository_Local.GetUserToken().Length > 0)
        {
            string decryptedUsername = Cryptography.Decrypt(Repository_Local.GetUserToken());
            return decryptedUsername;
        }
        return null;
    }

    public static void RemoveSavedUserAndForget()
    {
        Repository_Local.SetUserToken("");
        Repository_Local.SetIsUserRemembered(0);
    }

    public static bool IsUserRemembered()
    {
        if (Repository_Local.IsUserRemembered() == 1)
        {
            return true;
        }
        return false;
    }

    public static bool IsUserAuthorized()
    {
        return Repository_Local.GetUserToken().Length > 0;
    }

    public static void SetDataOnFirstRun()
    {
        if (Repository_Local.IsFirstGameRun() == 1)
        {
            Repository_Local.SetIsFirstGameRun(0);
            Repository_Local.SetIsUserRemembered(0);
            Repository_Local.SetUserToken("");
        }
    }

    public static void ShowTooltips()
    {
        Repository_Local.SetMustShowTooltips(1);
    }

    public static void HideTooltips()
    {
        Repository_Local.SetMustShowTooltips(0);
    }

    public static bool MustShowTooltips()
    {
        if (Repository_Local.MustShowTooltips() == 1)
        {
            return true;
        }
        return false;
    }
}
