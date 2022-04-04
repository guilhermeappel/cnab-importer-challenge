using System;
using System.IO;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CNAB.Importer.AutomatedTests.Tests;

public class Tests
{
    private IWebDriver _driver;

    [OneTimeSetUp]
    public void Setup()
    {
        var path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Drivers");

        _driver = new ChromeDriver(path);
    }

    [Test]
    public void UserValidate_Register_Success()
    {
        _driver.Navigate().GoToUrl("http://localhost:3000/register");

        var username = Guid.NewGuid().ToString();
        var password = Guid.NewGuid().ToString()[..15];

        RegisterUser(username, password);

        Assert.True(_driver.Url.Contains("/login"));

    }

    [Test]
    public void UserValidate_Register_Fail()
    {
        _driver.Navigate().GoToUrl("http://localhost:3000/register");

        var registerLinkButton = _driver.FindElement(By.Id("register"));
        registerLinkButton.Click();

        Thread.Sleep(1000);

        var registerButton = _driver.FindElement(By.Id("register"));
        registerButton.Click();

        Thread.Sleep(1000);

        var usernameErrorLabel = _driver.FindElement(By.Id("username-error"));
        var passwordErrorLabel = _driver.FindElement(By.Id("password-error"));
        var passwordConfirmationErrorLabel = _driver.FindElement(By.Id("passwordConfirmation-error"));

        Assert.True(usernameErrorLabel.Displayed);
        Assert.True(passwordErrorLabel.Displayed);
        Assert.True(passwordConfirmationErrorLabel.Displayed);
    }

    [Test]
    public void UserValidate_Login_Success()
    {
        _driver.Navigate().GoToUrl("http://localhost:3000");

        var username = Guid.NewGuid().ToString();
        var password = Guid.NewGuid().ToString()[..15];

        RegisterUser(username, password);

        var usernameTextField = _driver.FindElement(By.Id("username"));

        usernameTextField.Clear();
        usernameTextField.SendKeys(username);

        var passwordTextField = _driver.FindElement(By.Id("password"));

        passwordTextField.Clear();
        passwordTextField.SendKeys(password);

        var loginButton = _driver.FindElement(By.Id("login"));
        loginButton.Click();

        Thread.Sleep(1000);

        var uploadFileButton = _driver.FindElement(By.Id("upload-file"));

        Assert.True(uploadFileButton.Displayed);
    }

    [Test]
    public void UserValidate_Login_Fail()
    {
        _driver.Navigate().GoToUrl("http://localhost:3000");

        var registerLinkButton = _driver.FindElement(By.Id("login"));
        registerLinkButton.Click();

        Thread.Sleep(200);

        var invalidLoginErrorLabel = _driver.FindElement(By.Id("invalidLogin-error"));

        Assert.True(invalidLoginErrorLabel.Displayed);
    }

    #region Auxiliary Methods

    private void RegisterUser(string username, string password)
    {
        var registerLinkButton = _driver.FindElement(By.Id("register"));
        registerLinkButton.Click();

        Thread.Sleep(1000);

        var usernameTextField = _driver.FindElement(By.Id("username"));

        usernameTextField.Clear();
        usernameTextField.SendKeys(username);

        Thread.Sleep(200);

        var passwordTextField = _driver.FindElement(By.Id("password"));

        passwordTextField.Clear();
        passwordTextField.SendKeys(password);

        Thread.Sleep(200);

        var passwordConfirmationTextField = _driver.FindElement(By.Id("passwordConfirmation"));

        passwordConfirmationTextField.Clear();
        passwordConfirmationTextField.SendKeys(password);

        Thread.Sleep(200);

        var registerButton = _driver.FindElement(By.Id("register"));
        registerButton.Click();

        Thread.Sleep(1000);
    }

    #endregion
}