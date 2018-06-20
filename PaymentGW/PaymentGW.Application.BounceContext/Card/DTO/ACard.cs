using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentGW.Application.BounceContext.Validation.DTO;

namespace PaymentGW.Application.BounceContext.Card.DTO {
    public abstract class ACard {
        protected ACard(string cardNumber, int expiryYear, CardType cardType) {
            this.CardNumber = cardNumber;
            this.ExpiryYear = expiryYear;
            this.CardType = cardType;
        }
        public string CardNumber { get; set; }
        public int ExpiryYear { get; set; }
        protected CardType CardType { get; set; }
        public abstract bool IsValid();
        public abstract CardType GetCardType();
    }
}
