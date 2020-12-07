using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Instagram_Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var driver = new ChromeDriver())
            {
                // Wait 10 Seconds after any request or page reloads.
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                driver.Navigate().GoToUrl("https://www.instagram.com/");

                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#loginForm > div > div:nth-child(1) > div > label > input")));

                var usernameInput = driver.FindElement(By.CssSelector("#loginForm > div > div:nth-child(1) > div > label > input"));
                usernameInput.SendKeys("YOUR_INSTAGRAM_USERNAME");
                var passwordInput = driver.FindElement(By.CssSelector("#loginForm > div > div:nth-child(2) > div > label > input"));
                passwordInput.SendKeys("YOUR_INSTAGRAM_PASSWORD");

                var loginElement = driver.FindElement(By.CssSelector("#loginForm > div > div:nth-child(3) > button"));
                loginElement.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#react-root > section > main > div > div > div > div > button")));

                // Close Save Login Info
                if (driver.FindElement(By.CssSelector("#react-root > section > main > div > div > div > div > button")).Displayed)
                {
                    var loginSaveInfoNowNowButtonElement = driver.FindElement(By.CssSelector("#react-root > section > main > div > div > div > div > button"));
                    loginSaveInfoNowNowButtonElement.Click();
                }

                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("body > div.RnEpo.Yx5HN > div > div > div > div.mt3GC > button.aOOlW.HoLwm")));

                // Close Notification Popup
                if (driver.FindElement(By.CssSelector("body > div.RnEpo.Yx5HN > div > div > div > div.mt3GC > button.aOOlW.HoLwm")).Displayed)
                {
                    var notificationNowNowButtonElement = driver.FindElement(By.CssSelector("body > div.RnEpo.Yx5HN > div > div > div > div.mt3GC > button.aOOlW.HoLwm"));
                    notificationNowNowButtonElement.Click();
                }

                var searchBarElement = driver.FindElement(By.CssSelector("#react-root > section > nav > div._8MQSO.Cx7Bp > div > div > div.LWmhU._0aCwM > input"));
                searchBarElement.SendKeys("kodkaresi");

                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#react-root > section > nav > div._8MQSO.Cx7Bp > div > div > div.LWmhU._0aCwM > div.drKGC")));

                var usersDivElements = driver.FindElement(By.CssSelector("#react-root > section > nav > div._8MQSO.Cx7Bp > div > div > div.LWmhU._0aCwM > div.drKGC"));

                var getUsersList = usersDivElements.FindElements(By.TagName("a"));

                var getFirstUser = getUsersList[0].GetAttribute("href");

                driver.Navigate().GoToUrl(getFirstUser);

                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#react-root > section > main > div > header > section > div.nZSzR > h2")));

                var followersButtonElement = driver.FindElement(By.CssSelector("#react-root > section > main > div > header > section > ul > li:nth-child(2) > a"));
                followersButtonElement.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("body > div.RnEpo.Yx5HN > div > div > div.isgrP > ul")));

                var followerUsersListDivElement = driver.FindElement(By.CssSelector("body > div.RnEpo.Yx5HN > div > div > div.isgrP > ul"));

                //var followerUsersListUlElement = followerUsersListDivElement.FindElement(By.TagName("ul"));
                var getUsers = followerUsersListDivElement.FindElements(By.TagName("li"));

                for (int i = 0;i < getUsers.Count; i++)
                {
                    var followButtonDivElement = getUsers[i].FindElement(By.CssSelector($"body > div.RnEpo.Yx5HN > div > div > div.isgrP > ul > div > li:nth-child({i + 1}) > div > div.Igw0E.rBNOH.YBx95.ybXk5._4EzTm.soMvl"));
                    var followButtonElement = followButtonDivElement.FindElement(By.TagName("button"));

                    if (followButtonElement.Text == "Follow")
                    {
                        followButtonElement.Click();
                    }
                }

                driver.Close();
            }
        }
    }
}
