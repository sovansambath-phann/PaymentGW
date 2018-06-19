using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentGW.Application.BounceContext.Card.Exceptions;

namespace PaymentGW.Application.BounceContext.Card.DTO {
    public static class CardFactory {
        public static ACard GetCard(string cardNumber,int expiryYear) {
            switch (cardNumber[0]){
                case '4': {
                    return new VisaCard(cardNumber, expiryYear);
                };
                case '5': {
                    return new MasterCard(cardNumber,expiryYear);
                };
                case '3': {
                    if (cardNumber.Length == 15) {
                        return new AmexCard(cardNumber,expiryYear);
                    }else {
                        return new JCBCard(cardNumber,expiryYear);
                    }
                };
                default : throw new UnknownCardException();
            }
        }
    }
}
