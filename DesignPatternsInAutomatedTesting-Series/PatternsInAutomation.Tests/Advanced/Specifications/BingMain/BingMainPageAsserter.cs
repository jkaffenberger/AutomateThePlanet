﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PatternsInAutomatedTests.Advanced.Specifications
{
    public static class BingMainPageAsserter
    {
        public static void AssertResultsCountIsAsExpected(this BingMainPage page, int expectedCount)
        {
            Assert.AreEqual(page.ResultsCountDiv.Text, expectedCount, "The results count is not as expected.");
        }
    }
}