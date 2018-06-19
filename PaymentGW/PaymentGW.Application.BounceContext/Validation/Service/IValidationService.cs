using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGW.Application.BounceContext.Validation.Service {
    public interface IValidationService {
        bool IsCardNumberFormatValid(string cardNumber);
        bool IsExpiryDateFormatValid(string expiryDate);
        bool IsCardExistInDB(string cardNumber);
    }
}
