using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentGW.Application.BounceContext.Validation.Exception;
using System.Text.RegularExpressions;
using PaymentGW.Application.BounceContext.Validation.DTO;
using PaymentGW.Domain.BounceContext.Card.Repository;

namespace PaymentGW.Application.BounceContext.Validation.Service {
    public class ValidationService :IValidationService{
        public ValidationResult Validate(string cardNumber, string expiryDate) {
            ValidationResult validationResult = new ValidationResult();
            validationResult.CardNumber = cardNumber;
            validationResult.IsValid = true;
            validationResult.Message = string.Empty;
            

            if (string.IsNullOrEmpty(cardNumber)) {
                validationResult.Message = "CardNumber can not be empty.";
                validationResult.IsValid = false;
                return validationResult;
            }

            if (cardNumber.Length != 15 && cardNumber.Length != 16) {
                validationResult.Message = "CardNumber must be 15 or 16 digits.";
                validationResult.IsValid = false;
                return validationResult;
            }


            if (!((cardNumber.StartsWith("3") || cardNumber.StartsWith("4") || cardNumber.StartsWith("5")))) {
                validationResult.Message = "CardNumber must start by digit 3,4 or 5.";
                validationResult.IsValid = false;
                return validationResult;
            }

            if (string.IsNullOrEmpty(expiryDate)) {
                validationResult.Message = "Expiry date can not be empty";
                validationResult.IsValid = false;
                return validationResult;
            }

            var regex = new Regex(@"^(0?[1-9]|1[0-2])\d\d\d\d$", RegexOptions.Singleline);
            if (!regex.IsMatch(expiryDate)) {
                validationResult.Message = "Expiry date must be in format MMYYYY";
                validationResult.IsValid = false;
                return validationResult;
            }

            ICardRepository repository = new CardRepository();
            var isExist = repository.IsCardExistInDB(cardNumber);
            if (!isExist) {
                validationResult.Message = "Card doesn't exist ";
                validationResult.IsValid = false;
                return validationResult;
            }

            return validationResult;
        }
    }
}
