﻿using System;
using OpenQA.Selenium;
using PatternsInAutomatedTests.Advanced.PageObjectv22.Base;

namespace PatternsInAutomatedTests.Advanced.PageObjectv22
{
    public partial class BingMainPage : BasePage
    {
        public IWebElement SearchBox
        {
            get
            {
                return this.driver.FindElement(By.Id("sb_form_q"));
            }
        }

        public IWebElement GoButton
        {
            get
            {
                return this.driver.FindElement(By.Id("sb_form_go"));
            }
        }

        public IWebElement ResultsCountDiv
        {
            get
            {
                return this.driver.FindElement(By.Id("b_tween"));
            }
        }
    }
}