using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentGW.Application.BounceContext.Card.Exceptions;

namespace PaymentGW.Application.BounceContext.Card.DTO {
    public class AmexCard :ACard{
        public AmexCard(string cardNumber,int expiryYear) : base(cardNumber,expiryYear){
            
        }
        public override bool IsValid() {
            if (CardNumber.Length != 15) {
                throw new InvalidCardException();
            }

            return true;
        }
    }
}
