using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGW.Application.BounceContext.Validation.DTO {
    public class ValidationResult {
        public string CardNumber { get; set; }
        public CardType CardType { get; set; }
        public bool IsValid { get; set; }
        public string Message { get; set; }
    }
}
