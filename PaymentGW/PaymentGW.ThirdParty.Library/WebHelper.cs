using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace PaymentGW.ThirdParty.Library {
    public class WebHelper {
        public string GetResponseHtml(string url, string method, string postJson) {
            var html = string.Empty;
            ServicePointManager.MaxServicePoints = 999999;
            ServicePointManager.DefaultConnectionLimit = 999999;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            ServicePointManager.CheckCertificateRevocationList = true;
            ServicePointManager.EnableDnsRoundRobin = true;
            ServicePointManager.ServerCertificateValidationCallback = ((object obj, X509Certificate x509Certificate, X509Chain x509Chain, SslPolicyErrors sslPolicyErrors) => true);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            if (method.ToUpper() == "POST") {
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) {
                    streamWriter.Write(postJson);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }

            using (var response = (HttpWebResponse)httpWebRequest.GetResponse()) {
                using (var streamReader = new StreamReader(response.GetResponseStream())) {
                    html = streamReader.ReadToEnd();
                }
            }

            return html;
        }
    }
}
