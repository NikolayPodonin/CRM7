using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM7.DataModel;
using CRM7.DataModel.Commercial;
using System.Collections.Generic;

namespace TestCRM7.DataModel
{
    [TestClass]
    public class ProposalPositionTest
    {
        [TestMethod]
        public void GetPriceTest()
        {
            ValveInPosition valve = new ValveInPosition() { Price = new CRM7.DataModel.Price() { BaseValue = 60, Currency = Currency.RUR } };
            RotorInPosition rotor = new RotorInPosition() { Price = new CRM7.DataModel.Price() { BaseValue = 3, Currency = Currency.EUR } };
            RotorOptionInPosition rotorOption = new RotorOptionInPosition() { Price = new CRM7.DataModel.Price() { BaseValue = 30, Currency = Currency.RUR } }; 
           
            ProposalPosition position = new ProposalPosition();

            position.Valve = valve;
            position.Rotor = rotor;
            position.RotorOptions = new List<RotorOptionInPosition>() { rotorOption };

            Assert.AreEqual(270m, position.GetCost(Currency.RUR, new CurrencyPair() { BaseCurrency = Currency.EUR, QuotedCurrency = Currency.RUR, Rate = 60 }));
            Assert.AreEqual(4.5m, position.GetCost(Currency.EUR, new CurrencyPair() { BaseCurrency = Currency.EUR, QuotedCurrency = Currency.RUR, Rate = 60 }));

            Assert.AreEqual(270m, position.GetCost(Currency.RUR, new CurrencyPair() { BaseCurrency = Currency.RUR, QuotedCurrency = Currency.EUR, Rate = 1 / 60m }));
            Assert.AreEqual(4.5m, position.GetCost(Currency.EUR, new CurrencyPair() { BaseCurrency = Currency.RUR, QuotedCurrency = Currency.EUR, Rate = 1 / 60m }));                 
        }
    }
}
