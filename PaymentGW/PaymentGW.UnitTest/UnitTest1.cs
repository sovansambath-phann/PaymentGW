using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentGW.Application.BounceContext.Card.DTO;
using PaymentGW.Application.BounceContext.Card.Exceptions;
using PaymentGW.Application.BounceContext.Card.Service;
using PaymentGW.Application.BounceContext.Validation.DTO;
using PaymentGW.Application.BounceContext.Validation.Service;


namespace PaymentGW.UnitTest {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void Test_InValid_VisaCard_NotLeapYear() {
            var cardNumber ="4111111111111111";
            var expiryYear = 2019;
            ACard card = CardFactory.GetCard(cardNumber, expiryYear);
            Assert.IsFalse(card.IsValid());
            Assert.AreEqual(CardType.Visa,card.GetCardType());
        }

        [TestMethod]
        public void Test_Valid_VisaCard_WithLeapYear() {
            var cardNumber = "4111111111111111";
            var expiryYear = 2020;
            ACard card = CardFactory.GetCard(cardNumber, expiryYear);
            Assert.IsTrue(card.IsValid());
            Assert.AreEqual(CardType.Visa, card.GetCardType());
        }

        [TestMethod]
        public void Test_InValid_MasterCard_NotPrimeNumber() {
            var cardNumber = "5111111111111111";
            var expiryYear = 2020;
            ACard card = CardFactory.GetCard(cardNumber, expiryYear);
            Assert.IsFalse(card.IsValid());
            Assert.AreEqual(CardType.Master, card.GetCardType());
        }

        [TestMethod]
        public void Test_Valid_MasterCard_PrimeNumber() {
            var cardNumber = "5111111111111111";
            var expiryYear = 2017;
            ACard card = CardFactory.GetCard(cardNumber, expiryYear);
            Assert.IsTrue(card.IsValid());
            Assert.AreEqual(CardType.Master, card.GetCardType());
        }


        [TestMethod]
        public void Test_Valid_AmexCard_15Digit_StartWith3() {
            var cardNumber = "311111111111111";
            var expiryYear = 2019;
            ACard card = CardFactory.GetCard(cardNumber, expiryYear);
            Assert.IsTrue(card.IsValid());
            Assert.AreEqual(CardType.Amex, card.GetCardType());
        }

        [TestMethod]
        public void Test_Valid_JCBCard_16Digit_StartWith3() {
            var cardNumber = "3111111111111111";
            var expiryYear = 2019;
            ACard card = CardFactory.GetCard(cardNumber, expiryYear);
            Assert.IsTrue(card.IsValid());
            Assert.AreEqual(CardType.JCB, card.GetCardType());
        }

        [TestMethod]
        [ExpectedException(typeof(UnknownCardException))]
        public void Test_NotFoundType_StartWith9() {
            var cardNumber = "9111111111111111";
            var expiryYear = 2019;
            ACard card = CardFactory.GetCard(cardNumber, expiryYear);
        }
    }
}
