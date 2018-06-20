using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentGW.Application.BounceContext.Validation.DTO;

namespace PaymentGW.Application.BounceContext.Validation.Service {
    public interface IValidationService {
        ValidationResult Validate(string cardNumber, string expiryDate);
    }
}
