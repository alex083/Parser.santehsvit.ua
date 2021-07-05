using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;


namespace Parser.santehsvit.ua
{
    class ParseHtml
    {
        static void Main(string[] args)
        {
            string File = @"D:\Users\alex0\source\repos\Parser.santehsvit.ua\Parser.santehsvit.ua\files\feed.csv"; //Укажите свой путь где нужно создать файл
            CsvWriter.CreateCsv(File, "title;price;link\n"); 
            string pathToFile = AppDomain.CurrentDomain.BaseDirectory + '\\';
            IWebDriver driver = new ChromeDriver(pathToFile);
            driver.Navigate().GoToUrl("https://santehsvit.ua/category/krany/");
            Thread.Sleep(5000);
            List<string> ListOfTitles = new List<string>(), ListOfPrices = new List<string>(), ListOfLinks = new List<string>(), CsvData = new List<string>();
            //Выбираем тег где хранится название товара
            List<IWebElement> listOfElements = driver.FindElements(By.XPath("//div[@class='preview fn_product']/div[@class='fn_transfer clearfix']/a[@class='product_name']")).ToList();
            foreach (IWebElement a in listOfElements)
                ListOfTitles.Add(a.Text);
            //Выбираем тег где хранится ссылка на товар
            listOfElements = driver.FindElements(By.XPath("//div[@class='preview fn_product']/div[@class='fn_transfer clearfix']/a")).ToList();
            foreach (IWebElement a in listOfElements) //Записиваем все ссылки в массив ListOfLinks
                ListOfLinks.Add(a.GetAttribute("href"));
            //Выбираем ссылку где хранится цена товара
            listOfElements = driver.FindElements(By.XPath("//div[@class='preview fn_product']/div[@class='fn_transfer clearfix']/div[@class='price_container price_container--w']/div[@class='prices__wrap']/div[@class='prices']/div[@class='price']/span[@class='fn_price']")).ToList();
           foreach (IWebElement a in listOfElements) //Записываем цены в массив ListOfPrices
                ListOfPrices.Add(a.Text);
            for (int i = 0; i < ListOfPrices.Count; i++)
            {
                CsvData.Add(ListOfTitles[i] + ";" + ListOfPrices[i] + ";" + ListOfLinks[i] + "\n");
                //Console.WriteLine(CsvData[i]);
                CsvWriter.CreateCsv(File, CsvData[i]);
            }
        }

    }
}
