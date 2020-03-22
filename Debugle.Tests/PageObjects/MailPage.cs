using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;


namespace Debugle.Tests
{
    public class MailPage
    {
        private IWebDriver _driver;
        By _clicCreatMail = By.XPath("//button[@class='default compose']");
        By _clicAdress = By.XPath("//div[@class='sendmsg__form-label-field auto cropped ui-sortable']");
        //By _clicTopic = By.XPath("//input[@class = 'input']");
        By _clicBodyMail = By.XPath("//body[@id='tinymce']']");
        By _clicButtonSend = By.XPath("//button[@class='default send']");
        By _clicButtonPodtverjdenie = By.XPath("//*[text()='Все равно отправить']");
        By _numberOfLetters = By.XPath("//span[@class='sidebar__list-link-count']");
        int NumbersLetterBase;
        public MailPage(IWebDriver driver)
        {
            _driver = driver;
            
        }
        public void ButtonCreatMail()
        {
            _driver.FindElement(_clicCreatMail).Click();
        }
       public void ClicFieldSend()
        {
            _driver.FindElement(_clicAdress).Click();
            Thread.Sleep(1000);
            
        }

        public void WriteMyMail(string mail)
        {
            IWebElement rte = _driver.SwitchTo().ActiveElement();
            rte.SendKeys(mail);
            _driver.SwitchTo().DefaultContent();
            Thread.Sleep(1000);
         }
       
        public void ClicSendMail()
        {
            _driver.FindElement(_clicButtonSend).Click();
            Thread.Sleep(1000);
        }
        public void ClicPodtverjdenie()
        {
            _driver.FindElement(_clicButtonPodtverjdenie).Click();
            Thread.Sleep(1000);
        }
        public string NumbersLetter()
        {
            return _driver.FindElement(_numberOfLetters).Text;
        }
       
    }
}
