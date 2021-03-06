﻿using System;
using PatternsInAutomatedTests.Advanced.Decorator.Data;
using PatternsInAutomatedTests.Advanced.Decorator.Enums;
using PatternsInAutomatedTests.Advanced.Decorator.Pages.PlaceOrderPage;
using PatternsInAutomatedTests.Advanced.Decorator.Services;

namespace PatternsInAutomatedTests.Advanced.Decorator.Advanced.Strategies
{
    public class VatTaxOrderPurchaseStrategy : OrderPurchaseStrategyDecorator
    {
        private readonly VatTaxCalculationService vatTaxCalculationService;
        private decimal vatTax;     

        public VatTaxOrderPurchaseStrategy(OrderPurchaseStrategy orderPurchaseStrategy, decimal itemsPrice, ClientPurchaseInfo clientPurchaseInfo) 
            : base(orderPurchaseStrategy, itemsPrice, clientPurchaseInfo)
        {
            this.vatTaxCalculationService = new VatTaxCalculationService();
        }

        public override decimal CalculateTotalPrice()
        {
            Countries currentCountry = (Countries)Enum.Parse(typeof(Countries), clientPurchaseInfo.BillingInfo.Country);
            this.vatTax = this.vatTaxCalculationService.Calculate(this.itemsPrice, currentCountry);
            return this.orderPurchaseStrategy.CalculateTotalPrice() + this.vatTax;
        }

        public override void ValidateOrderSummary(decimal totalPrice)
        {
            base.orderPurchaseStrategy.ValidateOrderSummary(totalPrice);
            PlaceOrderPage.Instance.Validate().EstimatedTaxPrice(vatTax.ToString());
        }
    }
}