using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentGW.ThirdParty.Library;
using PaymentGW.Application.BounceContext.Card.Exceptions;
using PaymentGW.Application.BounceContext.Validation.DTO;

namespace PaymentGW.Application.BounceContext.Card.DTO {
    public class MasterCard : ACard{
        public MasterCard(string cardNumber, int expiryYear,CardType cardType): base(cardNumber, expiryYear,cardType) {
            
        }

        public override bool IsValid() {
            var isPrimeNumber = PrimeNumberHelper.IsPrime(ExpiryYear);
            if (!isPrimeNumber) {
                return false;
            }

            return isPrimeNumber;
        }

        public override CardType GetCardType() {
            return base.CardType;
        }
    }
}
