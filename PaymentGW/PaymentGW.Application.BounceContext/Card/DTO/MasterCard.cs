using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentGW.ThirdParty.Library;
using PaymentGW.Application.BounceContext.Card.Exceptions;

namespace PaymentGW.Application.BounceContext.Card.DTO {
    public class MasterCard : ACard{
        public MasterCard(string cardNumber, int expiryYear): base(cardNumber, expiryYear) {
            
        }

        public override bool IsValid() {
            var isPrimeNumber = PrimeNumberHelper.IsPrime(ExpiryYear);
            if (!isPrimeNumber) {
                throw new InvalidCardException();
            }

            return isPrimeNumber;
        }
    }
}
