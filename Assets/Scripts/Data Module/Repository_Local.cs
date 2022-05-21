using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repository_Local 
{

    public static void SetIsFirstGameRun(int value)
    {
        PlayerPrefs.SetInt("isFirstGameRun", value);
    }

    public static int IsFirstGameRun()
    {
        return PlayerPrefs.GetInt("isFirstGameRun", 1);
    }

    public static void SetIsUserRemembered(int value)
    {
        PlayerPrefs.SetInt("isUserRemembered", value);
    }

    public static int IsUserRemembered()
    {
        return PlayerPrefs.GetInt("isUserRemembered");
    }

    public static void SetUserToken(string token)
    {
        PlayerPrefs.SetString("token", token);
    }

    public static string GetUserToken()
    {
        return PlayerPrefs.GetString("token");
    }

    public static void SetMustShowTooltips(int value)
    {
        PlayerPrefs.SetInt("mustShowTooltips", value);
    }

    public static int MustShowTooltips()
    {
        return PlayerPrefs.GetInt("mustShowTooltips", 1);
    }
}
