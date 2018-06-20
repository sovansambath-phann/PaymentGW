using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentGW.Domain.BounceContext.Card.DTO;

namespace PaymentGW.Domain.BounceContext.Card.Repository {
    public interface ICardRepository {
        CardDto GetCardByCardNumber(string cardNumber);
        CardDto[] GetAllCardInDB();
        bool IsCardExistInDB(string cardNumber);
    }
}
