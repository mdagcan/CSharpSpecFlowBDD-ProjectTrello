using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBDDAutomationFramework.Pages
{
    internal class TrelloPage
    {
        By loginButton = By.CssSelector(".Buttonsstyles__Button-sc-1jwidxo-0.kTwZBr[href='/login']");
        By emailField = By.CssSelector("#user");
        By continueButton = By.CssSelector("#login");
        By passwordField = By.CssSelector("#password");
        By loginAccount = By.CssSelector("button[id='login-submit'] span[class='css-178ag6o'] span");
    }
}
