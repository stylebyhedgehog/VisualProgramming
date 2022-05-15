using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Service_Auth
{
    private const int minUsernameLenght = 2;
    private const int minPasswordLenght = 2;

  
    private static Model_User composeModelUser(string username, string password)
    {
        Model_User user = new Model_User();
        user.Username = username;
        user.Password = Cryptography.Encrypt(password);
        user.Score = 0;
        user.Level = 1;
        user.CharacterId = 1;
        user.AvailableCharactersId = new List<int>() {1};
        return user;
    }

    public static Authentication_Result SignUp(string username, string password, string repeatPassowrd)
    {
        //matching validation
        if (password != repeatPassowrd)
        {
            return Authentication_Result.ERROR_SIGN_UP_PASSWORD_MATCHING;
        }
        //length validation
        if (username.Length < minUsernameLenght || password.Length < minPasswordLenght)
        {
            return Authentication_Result.ERROR_SIGN_UP_LENGTH;
        }

        //if exists
        Model_User user = Repository_User.GetUserByUsername(username);
        if (user != null)
        {
            return Authentication_Result.ERROR_SIGN_UP_EXISTS;
        }

        //compose + save
        Model_User newUser = composeModelUser(username, password);
        Repository_User.AddUser(newUser);
        SaveSystem.Instance.setCurrentUser(newUser, true);
        return Authentication_Result.SUCCESS_SIGN_UP;
    }

    public static Authentication_Result LogIn(string username, string password, bool rememberMe)
    {
        Model_User model_User = Repository_User.GetUserByUsername(username);
        if (model_User != null && Cryptography.Decrypt(model_User.Password) == password)
        {
            SaveSystem.Instance.setCurrentUser(model_User, rememberMe);
            return Authentication_Result.SUCCESS_LOG_IN;
        }
        else
        {
            return Authentication_Result.ERROR_LOG_IN_INCORRECT_DATA;
        }
    }
 
}

public enum Authentication_Result
{
    SUCCESS_LOG_IN,
    SUCCESS_SIGN_UP,
    ERROR_LOG_IN_INCORRECT_DATA,
    ERROR_SIGN_UP_LENGTH,
    ERROR_SIGN_UP_PASSWORD_MATCHING,
    ERROR_SIGN_UP_EXISTS,
    ERROR_SIGN_UP_DATABASE
}
