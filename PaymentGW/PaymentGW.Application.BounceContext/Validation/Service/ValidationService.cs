using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentGW.Application.BounceContext.Validation.Exception;
using System.Text.RegularExpressions;

namespace PaymentGW.Application.BounceContext.Validation.Service {
    public class ValidationService :IValidationService{
        public bool IsCardNumberFormatValid(string cardNumber) {
            if (string.IsNullOrEmpty(cardNumber)) {
                throw new EmptyCardException();
            }

            if (cardNumber.Length != 15 && cardNumber.Length != 16) {
                throw new CardNumberFormatException();
            }

            if (!((cardNumber.StartsWith("3") || cardNumber.StartsWith("4") || cardNumber.StartsWith("5")))) {
                throw new CardTypeNotFoundException();
            }

            return true;
        }

        public bool IsExpiryDateFormatValid(string expiryDate) {
            if (string.IsNullOrEmpty(expiryDate)) {
                throw new ExpiryDateFormatException();
            }

            var regex = new Regex(@"^(0?[1-9]|1[0-2])\d\d\d\d$", RegexOptions.Singleline);
            if (!regex.IsMatch(expiryDate)) { 
                throw new ExpiryDateFormatException();
            }

            return true;
        }

        public bool IsCardExistInDB(string cardNumber) {
            throw new NotImplementedException();
        }
    }
}
