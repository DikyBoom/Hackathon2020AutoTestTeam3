using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Debugle.Tests
{
    public class LoginPage
    {
        private IWebDriver _driver;
        By _userLoginLocator = By.XPath(".//*[@class='input-text__input input-text__input_size-regular']");
        By _userPasswordLocator = By.Id("id-p");
        By _loginButtonLocator = By.XPath(".//*[@type='submit']");
        By _errorMessageDivLocator = By.ClassName("form__error form__error_fail");
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
       }
        public void TypeUserLogin(string userLogin)
        {
            Thread.Sleep(1000);
driver.FindElement(_userPasswordLocator).SendKeys(userPassword);
        }

        public void ClickLoginButton()
        {
            _driver.FindElement(_loginButtonLocator).Click();
        }

        public string GiveErrorMessageText()
        {
            return _driver.FindElement(_errorMessageDivLocator).Text;
        }
    }

}
