using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Lab_3_WebScraper
{
    class Program
    {
        //public bool GoBack();
        //[Test]
        //[Repeat(20)]
        static void Main(string[] args)
        {
            IWebDriver driver;
            
            driver = new ChromeDriver(@"/Users/mpotapov/Projects/Lab_3_WebScraper/Lab_3_WebScraper/bin/");
            driver.Navigate().GoToUrl("https://rozetka.com.ua/ua/");

            var searchField = driver.FindElement(By.Name("search"));
            searchField.SendKeys("hp probook 450 g7 pike silver");

            var searchButtonSubmit = driver.FindElement(By.CssSelector("body > app-root > div > div:nth-child(2) > app-rz-header > header > div > div.header-bottomline > div.header-search.js-app-search-suggest > form > button"));
            searchButtonSubmit.Click();

            // scrape price value
            var priceOnMain = driver.FindElement(By.XPath("/html/body/app-root/div/div[1]/app-rz-search/div/main/search-result/div[2]/section/app-search-goods/ul/li[1]/app-goods-tile-default/div/div[2]/div[4]/div[2]/p")).GetAttribute("innerHTML");
            Console.Write(priceOnMain);

            //driver.GoBack();

            //////go to product page
            var notebookPage = driver.FindElement(By.ClassName("goods-tile__picture"));
            notebookPage.Click();

            ////// scrape price on product page page
            var priceOnProduct = driver.FindElement(By.XPath("/html/body/app-root/div/div[1]/app-rz-product/div/product-tab-main/div[1]/div[1]/div[2]/product-main-info/div/div/div/p[1]")).GetAttribute("innerHTML");
            Console.Write(priceOnProduct);

        }
    }
}