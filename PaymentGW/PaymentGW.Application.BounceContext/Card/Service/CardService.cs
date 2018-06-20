using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGW.Application.BounceContext.Card.Service {
    public class CardService : ICardService {
        public int GetCardExpiryYear(string expiryYear) {
            // the format of the date is MMYYYY
            string strYear = expiryYear.Substring(2, 4);
            int result =0;
            var isValid = int.TryParse(strYear, out result);
            if (!isValid) {
                throw new FormatException();
            }

            return result;
        }
    }
}
