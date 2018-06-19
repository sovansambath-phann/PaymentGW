using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentGW.Application.BounceContext.Card.Exceptions;

namespace PaymentGW.Application.BounceContext.Card.DTO {
    public class VisaCard : ACard{
        public VisaCard(string cardNumber, int expiryYear): base(cardNumber, expiryYear) {
            
        }

        public override bool IsValid() {
            var isLeapYear = DateTime.IsLeapYear(ExpiryYear);
            if (!isLeapYear) {
                throw new InvalidCardException();
            }

            return isLeapYear;
        }
    }
}
