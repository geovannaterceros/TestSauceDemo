using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace TestClass
{
    [TestClass]
    public class TestClass
    {
        IWebDriver webDriver;
        public TestClass() 
        {
            webDriver = new ChromeDriver(@"C:\SeleniumWebDrivers");

            webDriver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [TestMethod]
        public void MyFirstTest() 
        {
            IWebElement userInput = webDriver.FindElement(By.Id("user-name"));
            userInput.SendKeys("standard_user");

            IWebElement passwordInput = webDriver.FindElement(By.Id("password"));
            passwordInput.SendKeys("secret_sauce");

            IWebElement sendButton = webDriver.FindElement(By.Id("login-button"));
            sendButton.Click();

            IWebElement title = webDriver.FindElement(By.Id("item_4_title_link"));
            var actualTitle = title.Text;

            string expectedTitle = "Sauce Labs Backpack";

            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [TestMethod]
        public void SecondTest()
        {
            IWebElement userInput = webDriver.FindElement(By.Id("user-name"));
            userInput.SendKeys("standard_user");

            IWebElement passwordInput = webDriver.FindElement(By.Id("password"));
            passwordInput.SendKeys("secret_sauce");

            IWebElement sendButton = webDriver.FindElement(By.Id("login-button"));
            sendButton.Click();

            IWebElement title = webDriver.FindElement(By.Id("item_4_title_link"));
            var itemTitle = title.Text;

            IWebElement price = webDriver.FindElement(By.ClassName("inventory_item_price"));
            var priceItem = price.Text;


            IWebElement addCardSauce = webDriver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
            addCardSauce.Click();

            IWebElement cartA = webDriver.FindElement(By.ClassName("shopping_cart_link"));
            cartA.Click();

            IWebElement titleAdd = webDriver.FindElement(By.Id("item_4_title_link"));
            var itemTitleAdd = titleAdd.Text;

            IWebElement priceAdd = webDriver.FindElement(By.ClassName("inventory_item_price"));
            var priceItemAdd = priceAdd.Text;
            
            Assert.AreEqual(itemTitle, itemTitleAdd);
            Assert.AreEqual(priceItem, priceItemAdd);
        }

        [TestMethod]
        public void ThreeTest()
        {
            IWebElement userInput = webDriver.FindElement(By.Id("user-name"));
            userInput.SendKeys("standard_user");

            IWebElement passwordInput = webDriver.FindElement(By.Id("password"));
            passwordInput.SendKeys("secret_sauce");

            IWebElement sendButton = webDriver.FindElement(By.Id("login-button"));
            sendButton.Click();

            IWebElement addCardSauce = webDriver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
            addCardSauce.Click();

            IWebElement cartA = webDriver.FindElement(By.ClassName("shopping_cart_link"));
            cartA.Click();

            IWebElement checkoutButton = webDriver.FindElement(By.Id("checkout"));
            checkoutButton.Click();

            IWebElement firstNameInput = webDriver.FindElement(By.Id("first-name"));
            firstNameInput.SendKeys("Geovanna Lizette");

            IWebElement lastNameInput = webDriver.FindElement(By.Id("last-name"));
            lastNameInput.SendKeys("Gil Terceros");

            IWebElement postalCodeInput = webDriver.FindElement(By.Id("postal-code"));
            postalCodeInput.SendKeys("591");

            IWebElement continueButton = webDriver.FindElement(By.Id("continue"));
            continueButton.Click();

            IWebElement finishButton = webDriver.FindElement(By.Id("finish"));
            finishButton.Click();

            IWebElement thanksOrderMesage = webDriver.FindElement(By.ClassName("complete-header"));
            var actualMessage = thanksOrderMesage.Text;

            string expectedMessage = "THANK YOU FOR YOUR ORDER";

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void FourTest()
        {
            IWebElement userInput = webDriver.FindElement(By.Id("user-name"));
            userInput.SendKeys("standard_user");

            IWebElement passwordInput = webDriver.FindElement(By.Id("password"));
            passwordInput.SendKeys("secret_sauce");

            IWebElement sendButton = webDriver.FindElement(By.Id("login-button"));
            sendButton.Click();

            IWebElement title = webDriver.FindElement(By.Id("item_4_title_link"));
            var itemTitle = title.Text;

            IWebElement price = webDriver.FindElement(By.ClassName("inventory_item_price"));
            var priceItem = price.Text;


            IWebElement addCardSauce = webDriver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
            addCardSauce.Click();

            IWebElement numberCart = webDriver.FindElement(By.ClassName("shopping_cart_link"));
            var actualNumberCart = numberCart.Text;
            var expectNumberCard = "1";

            Assert.AreEqual(expectNumberCard, actualNumberCart);

            IWebElement carButton = webDriver.FindElement(By.ClassName("shopping_cart_link"));
            carButton.Click();

            IWebElement removeButton = webDriver.FindElement(By.Id("remove-sauce-labs-backpack"));
            removeButton.Click();

            IWebElement searchItem = webDriver.FindElement(By.ClassName("removed_cart_item"));
            var actualItem = searchItem != null;

            Assert.AreEqual(true, actualItem);

        }

        [TestMethod]
        public void FiveTest()
        {
            IWebElement userInput = webDriver.FindElement(By.Id("user-name"));
            userInput.SendKeys("locked_out_user");

            IWebElement passwordInput = webDriver.FindElement(By.Id("password"));
            passwordInput.SendKeys("secret_sauce");

            IWebElement sendButton = webDriver.FindElement(By.Id("login-button"));
            sendButton.Click();

            IWebElement title = webDriver.FindElement(By.XPath("//h3[@data-test]"));
            var actualTitle = title.Text;

            string expectedTitle = "Epic sadface: Sorry, this user has been locked out.";

            Assert.AreEqual(expectedTitle, actualTitle);
        }
    }
}
