using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentGW.Domain.BounceContext.Card.DTO;
using System.Data.Entity.Core.Objects;

namespace PaymentGW.Domain.BounceContext.Card.Repository {
    public class CardRepository : ICardRepository {
        PaymentGWDBEntities db = new PaymentGWDBEntities();
        public CardDto GetCardByCardNumber(string cardNumber) {
            var result = db.t_card.Where(w => w.CardNumber.Trim() == cardNumber).FirstOrDefault();
            return new CardDto() { 
                 CardNumber = result.CardNumber,
                 ExpiryDate = result.ExpiryDate.Value,
                 Id = result.Id
            };
        }

        public bool IsCardExistInDB(string cardNumber) {
            ObjectParameter outputParam = new ObjectParameter("result", typeof(int)); 
            db.IsCardNumberExists(cardNumber, outputParam);
            var castResult = (int)outputParam.Value;

            if (castResult == 1) {
                return true;
            }else {
                return false;
            }
        }


        public CardDto[] GetAllCardInDB() {
            return (from c in db.t_card
                    select new PaymentGW.Domain.BounceContext.Card.DTO.CardDto() {
                        CardNumber = c.CardNumber,
                        ExpiryDate = c.ExpiryDate.Value
                    }).ToArray();

        }
    }
}
