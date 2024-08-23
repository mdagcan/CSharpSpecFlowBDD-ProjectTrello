using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using System;
using SpecFlowBDDAutomationFramework.Utility;
using static RestAssured.Dsl;
using Gherkin.Ast;

namespace SpecFlowBDDAutomationFramework.StepDefinitions
{
    [Binding]
    public sealed class Feature1StepDefinitions
    {
        private IWebDriver driver;

       public Feature1StepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }


        [Given(@"Open the browser")]
        public void GivenOpenTheBrowser()
        {
         //   driver = new ChromeDriver();
         //   driver.Manage().Window.Maximize();
        }

        [When(@"Enter the URL")]
        public void WhenEnterTheURL()
        {
            driver.Url = "https://trello.com/";
            Thread.Sleep(1000);
            
        }

        [Then(@"Search for the Testers Talk")]
        public void ThenSearchForTheTestersTalk()
        {
            driver.FindElement(By.XPath("//*[@name='search_query']")).SendKeys(" Testers Talk ");
            driver.FindElement(By.XPath("//*[@name='search_query']")).SendKeys(Keys.Enter);
            By channelName = By.LinkText("Testers Talk");
            driver.FindElement(channelName).Click();
            Thread.Sleep(5000);
          //  driver.Quit();
        }

        [Then(@"Login with user name and password")]
        public void ThenLoginWithUserNameAndPassword()
        {
            By loginButton = By.CssSelector(".Buttonsstyles__Button-sc-1jwidxo-0.kTwZBr[href='/login']");
            By emailField = By.CssSelector("#user");
            By continueButton = By.CssSelector("#login");
            By passwordField = By.CssSelector("#password");
            By loginAccount = By.CssSelector("button[id='login-submit'] span[class='css-178ag6o'] span");
            
            Thread.Sleep(1000);
            driver.FindElement(loginButton).Click();
            Thread.Sleep(5000);
            driver.FindElement(emailField).SendKeys("mustafa.senturk001@gmail.com");
            driver.FindElement(continueButton).Click();
            Thread.Sleep(5000);
            driver.FindElement(passwordField).SendKeys("qwertyasdf123");
            Thread.Sleep(5000);
            driver.FindElement(loginAccount).Click();
            Thread.Sleep(5000);
        }


        [Then(@"Send API requests")]
        public void ThenSendAPIRequests()
        {
            // First Users Info
            String myKey = "yourKey";
            String myToken = "yourToken";
            String boardName = "ThisIsMyTestBoardRestAssured";
            // Second User Info
            String userKey = "yourKey";
            String userToken = "yourToken";
            String userEmail = "yourEmail";

            String boardId = "0";
            String cardId = "0";
            String listId = "0";

            String createBoard = "https://api.trello.com/1/boards?token=" + myToken + "&key=" + myKey + "&name=" + boardName;
            Console.WriteLine(createBoard);
            boardId = (string)Given().RelaxedHttpsValidation().When().Post(createBoard).Then().StatusCode(200).Extract().Body("id");
            Thread.Sleep(5000);

            String inviteMember = "https://api.trello.com/1/boards/" + boardId + "/members?email=" + userEmail + "&key=" + myKey + "&token=" + myToken;
            Console.WriteLine(inviteMember);
            Given().RelaxedHttpsValidation().When().Put(inviteMember).Then().StatusCode(200);
            Thread.Sleep(5000);

            String createList = "https://api.trello.com/1/lists/?token=" + myToken + "&key=" + myKey + "&idBoard=" + boardId + "&name=List 1";
            Console.WriteLine(createList);
            listId = (string)Given().RelaxedHttpsValidation().When().Post(createList).Then().StatusCode(200).Extract().Body("id");
            Thread.Sleep(5000);

            String createCard = "https://api.trello.com/1/cards/?idList=" + listId + "&token=" + myToken + "&key=" + myKey + "&name=Card Name";
            Console.WriteLine(createCard);
            cardId = (string)Given().RelaxedHttpsValidation().When().Post(createCard).Then().StatusCode(200).Extract().Body("id");
            Thread.Sleep(5000);

            String updateCard = "https://api.trello.com/1/cards/" + cardId + "?desc=This is an update.&name=Changed Name&token=" + myToken + "&key=" + myKey;
            Console.WriteLine(updateCard);
            Given().RelaxedHttpsValidation().When().Put(updateCard).Then().StatusCode(200);
            Thread.Sleep(5000);

            String deleteCard = "https://api.trello.com/1/cards/" + cardId + "?token=" + myToken + "&key=" + myKey;
            Console.WriteLine(deleteCard);
            Given().RelaxedHttpsValidation().When().Delete(deleteCard).Then().StatusCode(200);
            Thread.Sleep(5000);

            String deleteBoard = "https://api.trello.com/1/boards/" + boardId + "?token=" + myToken + "&key=" + myKey;
            Console.WriteLine(deleteBoard);
            Given().RelaxedHttpsValidation().When().Delete(deleteBoard).Then().StatusCode(200);


        }
    }
}