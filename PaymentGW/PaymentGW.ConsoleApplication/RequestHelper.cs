using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PaymentGW.Application.BounceContext.Validation.DTO;
using PaymentGW.Application.BounceContext.Card.DTO;
using PaymentGW.ThirdParty.Library;
namespace PaymentGW.ConsoleApplication {
    public class RequestHelper {
        public ValidationResult MakeRquest(string url) {
            string html = new WebHelper().GetResponseHtml(url, "GET", string.Empty);
            ValidationResult result = null;
            if (!string.IsNullOrEmpty(html)) {
                result = JsonConvert.DeserializeObject<ValidationResult>(html);
            }

            return result;
        }
    }
}
