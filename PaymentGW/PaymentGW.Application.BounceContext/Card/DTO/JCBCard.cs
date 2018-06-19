using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGW.Application.BounceContext.Card.DTO {
    public class JCBCard : ACard{
        public JCBCard(string cardNumber, int expiryYear): base(cardNumber, expiryYear) {
            
        }

        public override bool IsValid() {
            return true;
        }
    }
}
