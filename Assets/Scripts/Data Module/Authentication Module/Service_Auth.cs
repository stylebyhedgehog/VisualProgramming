
public static class Service_Auth
{
    private const int minUsernameLenght = 2;
    private const int minPasswordLenght = 2;

  
    public static Authentication_Result SignUp(string username, string password, string repeatPassowrd)
    {
        if (password != repeatPassowrd)
        {
            return Authentication_Result.ERROR_SIGN_UP_PASSWORD_MATCHING;
        }
        if (username.Length < minUsernameLenght || password.Length < minPasswordLenght)
        {
            return Authentication_Result.ERROR_SIGN_UP_LENGTH;
        }
        Model_User user = Controller_User.GetUserByUsername(username);
        if (user != null)
        {
            return Authentication_Result.ERROR_SIGN_UP_EXISTS;
        }
        return Authentication_Result.SUCCESS_SIGN_UP;
    }
    public static Authentication_Result LogIn(string inputPassword, Model_User foundUser)
    {
        if (foundUser != null && Cryptography.Decrypt(foundUser.Password) == inputPassword)
        {
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

