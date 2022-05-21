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
                return "����������� ��������";
            case (Authentication_Result.ERROR_LOG_IN_INCORRECT_DATA):
                return "������������ ������";
            default:
                return "������";
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
                return "����������� ��������";
            case (Authentication_Result.ERROR_SIGN_UP_EXISTS):
                return "����� �����";
            case (Authentication_Result.ERROR_SIGN_UP_LENGTH):
                return "����� � ������ ������ ���� ������ 6 ��������";
            case (Authentication_Result.ERROR_SIGN_UP_PASSWORD_MATCHING):
                return "������ �� ���������";
            case (Authentication_Result.ERROR_SIGN_UP_DATABASE):
                return "���������� ��� ���";
            default:
                return "������";
        }
    }

}
