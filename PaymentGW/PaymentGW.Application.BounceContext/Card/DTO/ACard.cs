using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGW.Application.BounceContext.Card.DTO {
    public abstract class ACard {
        protected ACard(string cardNumber, int expiryYear) {
            this.CardNumber = cardNumber;
            this.ExpiryYear = expiryYear;
        }
        public string CardNumber { get; set; }
        public int ExpiryYear { get; set; }
        public abstract bool IsValid();
    }
}
