using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Debugle.Tests
{
   public class MailPageTests
    {
        private const string _correctLogin = "hacaton2103@ukr.net";
        private const string _correctPassword = "?Qwerty12345";
        private const string _loginPageUrl = "https://accounts.ukr.net/login?client_id=9GLooZH9KjbBlWnuLkVX&drop_reason=logout";
        
        int NumbersLetterBase;

        [Fact]
        public void CheckThatItIsPossibleToClicCreatMail()
        {

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(_loginPageUrl);
            LoginPage loginPage = new LoginPage(driver);
            loginPage.TypeUserLogin(_correctLogin);
            loginPage.TypeUserPassword(_correctPassword);
            loginPage.ClickLoginButton();
            Thread.Sleep(3000);
            MailPage mailPage = new MailPage(driver);

            try { NumbersLetterBase = Convert.ToInt32(mailPage.NumbersLetter());  }
            catch { NumbersLetterBase = 0; }

                mailPage.ButtonCreatMail();
                mailPage.WriteMyMail(_correctLogin);
                mailPage.ClicSendMail();
                mailPage.ClicPodtverjdenie();
                MailPage mailPage2 = new MailPage(driver);
                int NumbersLetter = Convert.ToInt32(mailPage2.NumbersLetter());
                int actual = NumbersLetter - NumbersLetterBase;
                Assert.Equal(1, actual);
                driver.Quit();
            
        }
    }
}
