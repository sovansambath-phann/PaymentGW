namespace PaymentGW.Application.BounceContext.Card.DTO{
    public class CardDto{
        public CardDto(string cardNumber,string expiryYear) {
            this.CardNumber = cardNumber;
            this.ExpiryYear = expiryYear;
        }

        public string CardNumber { get; set; }
        public string ExpiryYear { get; set; }
    }
}