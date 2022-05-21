using System;

public class Controller_Auth
{
    public static Action logIn_success;
    public static string TryToLogIn(string username, string password, bool remember)
    {
        Model_User foundUser = Controller_User.GetUserByUsername(username);
        Authentication_Result result = Service_Auth.LogIn(password, foundUser);
        switch (result)
        {
            case (Authentication_Result.SUCCESS_LOG_IN):
                if (remember)
                {
                    Controller_Local.SaveUserAndRemember(username);
                }
                else
                {
                    Controller_Local.SaveUserAndForget(username);
                }
                logIn_success?.Invoke();
                return "Авторизация пройдена";
            case (Authentication_Result.ERROR_LOG_IN_INCORRECT_DATA):
                return "Неправильные данные";
            default:
                return "Ошибка";
        }
    }

    public static string TryToSignUp(string username, string password, string repeatPassword)
    {
        Authentication_Result result = Service_Auth.SignUp(username, password, repeatPassword);
        switch (result)
        {
            case (Authentication_Result.SUCCESS_SIGN_UP):
                Model_User newUser = Controller_User.AddNeWUser(username, password);
                Controller_Local.SaveUserAndRemember(username);
                logIn_success?.Invoke();
                return "Регистрация пройдена";
            case (Authentication_Result.ERROR_SIGN_UP_EXISTS):
                return "Логин занят";
            case (Authentication_Result.ERROR_SIGN_UP_LENGTH):
                return "Логин и пароль должны быть больше 6 символов";
            case (Authentication_Result.ERROR_SIGN_UP_PASSWORD_MATCHING):
                return "Пароли не совпадают";
            case (Authentication_Result.ERROR_SIGN_UP_DATABASE):
                return "Попробуйте еще раз";
            default:
                return "Ошибка";
        }
    }

}
