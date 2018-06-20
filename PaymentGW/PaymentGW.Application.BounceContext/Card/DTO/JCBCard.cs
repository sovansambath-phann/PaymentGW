using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentGW.Application.BounceContext.Card.Exceptions;
using PaymentGW.Application.BounceContext.Card.DTO;
using PaymentGW.Application.BounceContext.Validation.DTO;

namespace PaymentGW.Application.BounceContext.Card.DTO {
    public class JCBCard : ACard{
        public JCBCard(string cardNumber, int expiryYear,CardType cardType): base(cardNumber, expiryYear,cardType) {
            
        }

        public override bool IsValid() {
            return true;
        }

        public override CardType GetCardType() {
            return base.CardType;
        }
    }
}
