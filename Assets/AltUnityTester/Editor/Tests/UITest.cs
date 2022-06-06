using NUnit.Framework;
using Altom.AltUnityDriver;

public class UITest
{
    public AltUnityDriver altUnityDriver;
    [OneTimeSetUp]
    public void SetUp()
    {
        altUnityDriver =new AltUnityDriver();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        altUnityDriver.Stop();
    }

    [Test, Order(5)]
    public void LogOut()
    {
        altUnityDriver.LoadScene("MainMenu");
        altUnityDriver.FindObject(By.NAME, "logOut").Click();
        altUnityDriver.WaitForCurrentSceneToBe("StartScene");
    }

    [Test, Order(4)]
    public void LevelChanged()
    {
        altUnityDriver.LoadScene("MainMenu");
        altUnityDriver.FindObject(By.NAME, "Play").Click();
        altUnityDriver.WaitForCurrentSceneToBe("Level1");
    }
    [Test, Order(3)]
    public void LogIn()
    {
        altUnityDriver.LoadScene("LogInScene");
        altUnityDriver.FindObject(By.NAME, "username").SetText("ddzaaa");
        altUnityDriver.FindObject(By.NAME, "password").SetText("ddzaaa");
        altUnityDriver.FindObject(By.NAME, "logIn").Click();
        altUnityDriver.WaitForCurrentSceneToBe("MainMenu");
    }
    [Test, Order(2)]
    public void SignUp()
    {
        altUnityDriver.LoadScene("SignUpScene");
        altUnityDriver.FindObject(By.NAME, "username").SetText("login123");
        altUnityDriver.FindObject(By.NAME, "password").SetText("ddzaaa");
        altUnityDriver.FindObject(By.NAME, "reeatPassword").SetText("ddzaaa");
        altUnityDriver.FindObject(By.NAME, "signUp").Click();
        altUnityDriver.WaitForCurrentSceneToBe("MainMenu");
    }
    [Test, Order(1)]
    public void StartGame()
    {
        altUnityDriver.LoadScene("StartScene");
        altUnityDriver.WaitForCurrentSceneToBe("StartScene");
    }
}