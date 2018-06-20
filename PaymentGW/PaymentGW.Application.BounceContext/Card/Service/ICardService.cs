using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGW.Application.BounceContext.Card.Service {
    public interface ICardService {
        int GetCardExpiryYear(string expiryYear);
    }
}
